# UpdateFunctionApps

Update Function Apps - This allows admins to quickly and easily deploy the latest version of Zips to keep the function apps for used for SMS, WhatsApp, and Cosmos REST API secure with the latest changes.

The following will need to be provided manually for security reasons:

The CustomSettings.json file is specific to the Update Function Apps tool and is required for the application to function correctly.

This files needs to be located in the same location as the application.

These values should point to the location of the current version of the ZIP files. They can start with "https://" or a local directory, such as "C:\\Users\\etc\\zip.zip":
```
{
  "SMSFunctionZipDeployPath": "",
  "WhatsAppFunctionZipDeployPath": "",
  "CosmosRESTZipDeployPath": ""
}
```

This application is dependent on the following library: [AASP Global Library](https://github.com/wrharper/AASPGlobalLibrary)
