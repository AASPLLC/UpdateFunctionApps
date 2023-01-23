using Azure.ResourceManager.Resources;
using System.Net.Http.Headers;
using AASPGlobalLibrary;
using Azure.ResourceManager;
using Azure;
using Azure.ResourceManager.AppService;
using System.Text.Json;

namespace UpdateFunctionApps
{
    public partial class InstallConfig : Form
    {
        readonly ArmClient client = TokenHandler.CreateArmClient();

        public SubscriptionResource? SelectedSubscription;
        public ResourceGroupResource? SelectedGroup;

        JSONCustomSettings json = new();

        public InstallConfig()
        {
            InitializeComponent();

            _ = new SetConsoleOutput(outputRT);
        }

        List<SubscriptionResource> subids = new();

        public (List<string>, List<SubscriptionResource>) SetupSubscriptionName()
        {
            List<string> names = new();
            List<SubscriptionResource> ids = new();
            SubscriptionCollection subscriptions = client.GetSubscriptions();
            List<SubscriptionResource> subs = subscriptions.GetAll().ToList();
            for (int i = 0; i < subs.Count; i++)
            {
                names.Add(subs[i].Data.DisplayName);
                ids.Add(subs[i]);
            }
            return (names, ids);
        }

        public static (List<string>, List<ResourceGroupResource>) SetupResourceName(SubscriptionResource sr)
        {
            List<string> names = new();
            List<ResourceGroupResource> ids = new();
            ResourceGroupCollection resourceGroups = sr.GetResourceGroups();
            foreach (var item in resourceGroups)
            {
                names.Add(item.Data.Name);
                ids.Add(item);
            }
            return (names, ids);
        }

        private async void InstallConfig_Load(object sender, EventArgs e)
        {
#pragma warning disable CS8601
            json = JsonSerializer.Deserialize<JSONCustomSettings>(await File.ReadAllTextAsync(Environment.CurrentDirectory + "/CustomSettings.json"));
#pragma warning restore CS8601

            (var names, subids) = SetupSubscriptionName();
            comboBox1.Items.AddRange(names.ToArray());
            comboBox1.SelectedIndex = 0;

            var disco = "https://globaldisco.crm.dynamics.com/api/discovery/v1.0/Instances";

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await TokenHandler.GetGlobalDynamicsImpersonationToken());
            HttpRequestMessage request = new(new("GET"), disco);
            _ = await httpClient.SendAsync(request);
        }

        public class JSONCustomSettings
        {
            public string? SMSFunctionZipDeployPath { get; set; }
            public string? WhatsAppFunctionZipDeployPath { get; set; }
            public string? CosmosRESTZipDeployPath { get; set; }
        }

        private async void SelectSubscription_Click(object sender, EventArgs e)
        {
            SelectedSubscription = subids[comboBox1.SelectedIndex];
            SelectedGroup = await SelectedSubscription.GetResourceGroups().GetAsync("SMSAndWhatsAppResourceGroup");


            outputRT.Text = "Getting Functions...";
            List<WebSiteResource> sites = SelectedGroup.GetWebSites().GetAll().ToList();
            for (int i = 0; i < sites.Count; i++)
            {
                smsFunctionCB.Items.Add(sites[i].Data.Name);
                whatsAppFunctionCB.Items.Add(sites[i].Data.Name);
                selectCosmosCB.Items.Add(sites[i].Data.Name);
            }
            for (int i = 0; i < smsFunctionCB.Items.Count; i++)
            {
                if (smsFunctionCB.Items[i].ToString().EndsWith("SMSApp"))
                {
                    smsFunctionCB.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < whatsAppFunctionCB.Items.Count; i++)
            {
                if (whatsAppFunctionCB.Items[i].ToString().EndsWith("WhatsApp"))
                {
                    whatsAppFunctionCB.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < selectCosmosCB.Items.Count; i++)
            {
                if (selectCosmosCB.Items[i].ToString().EndsWith("CosmosREST"))
                {
                    selectCosmosCB.SelectedIndex = i;
                    break;
                }
            }
            outputRT.Text += Environment.NewLine + "Functions found are now listed.";

            selectSubBTN.Enabled = false;
            comboBox1.Enabled = false;
            subids.Clear();
            selectSMSBTN.Enabled = true;
            smsFunctionCB.Enabled = true;
        }

        private void SelectSMS_Click(object sender, EventArgs e)
        {
            selectSMSBTN.Enabled = false;
            smsFunctionCB.Enabled = false;
            selectWhatsAppBTN.Enabled = true;
            whatsAppFunctionCB.Enabled = true;
        }

        private void SelectWhatsApp_Click(object sender, EventArgs e)
        {
            selectSubBTN.Enabled = false;
            comboBox1.Enabled = false;
            selectWhatsAppBTN.Enabled = false;
            whatsAppFunctionCB.Enabled = false;
            selectSMSBTN.Enabled = false;
            smsFunctionCB.Enabled = false;
            selectCosmosBTN.Enabled = true;
            selectCosmosCB.Enabled = true;
        }

        private async void SelectCosmos_Click(object sender, EventArgs e)
        {
            var results = MessageBox.Show("Warning: This will stop all SMS and WhatsApp messages temporarily." + Environment.NewLine + "Only do this when active users are at a low usage rate.", "", MessageBoxButtons.OKCancel);
            if (results == DialogResult.OK)
            {
                selectSubBTN.Enabled = false;
                comboBox1.Enabled = false;
                selectWhatsAppBTN.Enabled = false;
                whatsAppFunctionCB.Enabled = false;
                selectSMSBTN.Enabled = false;
                smsFunctionCB.Enabled = false;
                selectCosmosBTN.Enabled = false;
                selectCosmosCB.Enabled = false;
                outputRT.Text = "Getting Ready...";
#pragma warning disable CS8604
                var smsSiteResource = (await SelectedGroup.GetWebSiteAsync(smsFunctionCB.Text)).Value;
                PublishingUserResource user = (await smsSiteResource.GetPublishingCredentialsAsync(WaitUntil.Completed)).Value;
                outputRT.Text += Environment.NewLine + "Zip Deploy Started for SMS Function";
                await FunctionAppHandler.ZipDeploy(user, json.SMSFunctionZipDeployPath);
                outputRT.Text += Environment.NewLine + "Zip Deploy for SMS Function finished";

                var whatsAppSiteResource = (await SelectedGroup.GetWebSiteAsync(whatsAppFunctionCB.Text)).Value;
                user = (await whatsAppSiteResource.GetPublishingCredentialsAsync(WaitUntil.Completed)).Value;
                outputRT.Text += Environment.NewLine + "Zip Deploy Started for WhatsApp Function";
                await FunctionAppHandler.ZipDeploy(user, json.WhatsAppFunctionZipDeployPath);
                outputRT.Text += Environment.NewLine + "Zip Deploy for WhatsApp Function finished";

                if (selectCosmosCB.Text != "")
                {
                    var cosmosSiteResource = (await SelectedGroup.GetWebSiteAsync(selectCosmosCB.Text)).Value;
                    user = (await cosmosSiteResource.GetPublishingCredentialsAsync(WaitUntil.Completed)).Value;
                    outputRT.Text += Environment.NewLine + "Zip Deploy Started for Cosmos REST API Function";
                    await FunctionAppHandler.ZipDeploy(user, json.CosmosRESTZipDeployPath);
                    outputRT.Text += Environment.NewLine + "Zip Deploy for Cosmos REST API Function finished";
                }
#pragma warning restore CS8604
                selectSubBTN.Enabled = true;
                comboBox1.Enabled = true;
                selectWhatsAppBTN.Enabled = true;
                whatsAppFunctionCB.Enabled = true;
                selectSMSBTN.Enabled = true;
                smsFunctionCB.Enabled = true;
                selectCosmosBTN.Enabled = true;
                selectCosmosCB.Enabled = true;
            }
        }
    }
}
