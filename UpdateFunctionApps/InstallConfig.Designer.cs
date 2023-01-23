namespace UpdateFunctionApps
{
    partial class InstallConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectSubBTN = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.smsFunctionCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectSMSBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.whatsAppFunctionCB = new System.Windows.Forms.ComboBox();
            this.selectWhatsAppBTN = new System.Windows.Forms.Button();
            this.outputRT = new System.Windows.Forms.RichTextBox();
            this.selectCosmosBTN = new System.Windows.Forms.Button();
            this.selectCosmosCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectSubBTN
            // 
            this.selectSubBTN.Location = new System.Drawing.Point(430, 27);
            this.selectSubBTN.Name = "selectSubBTN";
            this.selectSubBTN.Size = new System.Drawing.Size(75, 23);
            this.selectSubBTN.TabIndex = 0;
            this.selectSubBTN.Text = "Select";
            this.selectSubBTN.UseVisualStyleBackColor = true;
            this.selectSubBTN.Click += new System.EventHandler(this.SelectSubscription_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(411, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Subscription for Update";
            // 
            // smsFunctionCB
            // 
            this.smsFunctionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smsFunctionCB.Enabled = false;
            this.smsFunctionCB.FormattingEnabled = true;
            this.smsFunctionCB.Location = new System.Drawing.Point(13, 71);
            this.smsFunctionCB.Name = "smsFunctionCB";
            this.smsFunctionCB.Size = new System.Drawing.Size(411, 23);
            this.smsFunctionCB.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select SMS Function App:";
            // 
            // selectSMSBTN
            // 
            this.selectSMSBTN.Enabled = false;
            this.selectSMSBTN.Location = new System.Drawing.Point(430, 71);
            this.selectSMSBTN.Name = "selectSMSBTN";
            this.selectSMSBTN.Size = new System.Drawing.Size(75, 23);
            this.selectSMSBTN.TabIndex = 8;
            this.selectSMSBTN.Text = "Select";
            this.selectSMSBTN.UseVisualStyleBackColor = true;
            this.selectSMSBTN.Click += new System.EventHandler(this.SelectSMS_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select WhatsApp Function App:";
            // 
            // whatsAppFunctionCB
            // 
            this.whatsAppFunctionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.whatsAppFunctionCB.Enabled = false;
            this.whatsAppFunctionCB.FormattingEnabled = true;
            this.whatsAppFunctionCB.Location = new System.Drawing.Point(13, 115);
            this.whatsAppFunctionCB.Name = "whatsAppFunctionCB";
            this.whatsAppFunctionCB.Size = new System.Drawing.Size(411, 23);
            this.whatsAppFunctionCB.TabIndex = 10;
            // 
            // selectWhatsAppBTN
            // 
            this.selectWhatsAppBTN.Enabled = false;
            this.selectWhatsAppBTN.Location = new System.Drawing.Point(430, 115);
            this.selectWhatsAppBTN.Name = "selectWhatsAppBTN";
            this.selectWhatsAppBTN.Size = new System.Drawing.Size(75, 23);
            this.selectWhatsAppBTN.TabIndex = 11;
            this.selectWhatsAppBTN.Text = "Select";
            this.selectWhatsAppBTN.UseVisualStyleBackColor = true;
            this.selectWhatsAppBTN.Click += new System.EventHandler(this.SelectWhatsApp_Click);
            // 
            // outputRT
            // 
            this.outputRT.Location = new System.Drawing.Point(10, 187);
            this.outputRT.Name = "outputRT";
            this.outputRT.Size = new System.Drawing.Size(495, 129);
            this.outputRT.TabIndex = 12;
            this.outputRT.Text = "";
            // 
            // selectCosmosBTN
            // 
            this.selectCosmosBTN.Enabled = false;
            this.selectCosmosBTN.Location = new System.Drawing.Point(430, 157);
            this.selectCosmosBTN.Name = "selectCosmosBTN";
            this.selectCosmosBTN.Size = new System.Drawing.Size(75, 24);
            this.selectCosmosBTN.TabIndex = 15;
            this.selectCosmosBTN.Text = "Start";
            this.selectCosmosBTN.UseVisualStyleBackColor = true;
            this.selectCosmosBTN.Click += new System.EventHandler(this.SelectCosmos_Click);
            // 
            // selectCosmosCB
            // 
            this.selectCosmosCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectCosmosCB.Enabled = false;
            this.selectCosmosCB.FormattingEnabled = true;
            this.selectCosmosCB.Location = new System.Drawing.Point(13, 158);
            this.selectCosmosCB.Name = "selectCosmosCB";
            this.selectCosmosCB.Size = new System.Drawing.Size(411, 23);
            this.selectCosmosCB.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Select Cosmos REST Function App:";
            // 
            // InstallConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 328);
            this.Controls.Add(this.selectCosmosBTN);
            this.Controls.Add(this.selectCosmosCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.outputRT);
            this.Controls.Add(this.selectWhatsAppBTN);
            this.Controls.Add(this.whatsAppFunctionCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectSMSBTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.smsFunctionCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.selectSubBTN);
            this.Name = "InstallConfig";
            this.Text = "Check for updates";
            this.Load += new System.EventHandler(this.InstallConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button selectSubBTN;
        private ComboBox comboBox1;
        private Label label1;
        private ComboBox smsFunctionCB;
        private Label label3;
        private Button selectSMSBTN;
        private Label label2;
        private ComboBox whatsAppFunctionCB;
        private Button selectWhatsAppBTN;
        private RichTextBox outputRT;
        private Button selectCosmosBTN;
        private ComboBox selectCosmosCB;
        private Label label4;
    }
}