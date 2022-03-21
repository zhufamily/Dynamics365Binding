# Dynamics 365 Binding
## _A custom binding for Dynamics 365 inside Azure function_
## Features

- Output binding for multiple Dynamics 365 Organization Requests
- Input / output binding for Dynamcis 365 Service Client
## Dependencies
- .Net 6.x
- Microsoft.Azure.WebJob 3.0.31+
- Microsoft.Azure.WebJob.Core 3.0.31+
- Microsoft.PowerPlatform.Dataverse.Client 0.6.1+

## Installation

It is available on public Nuget

It is also avaliable at PCX Nuget artifact source url https://pkgs.dev.azure.com/pcxhub-Procentrix/Procentrix.Crm.Base/_packaging/PcxCrmBase/nuget/v3/index.json

Install the package and all dependencies.

```sh
PM> Install-Package Dynamics365CustomBinding -version <latest_version>
```

## Samples

Dynamics 365 Binding can be used as in following samples

### Output Binding Usage

If all you need is just to send some commands to Dyancmis 365 and not care about their retuns or futhre actions, Dyanmics 365 Output Binding can be used as below

```sh
[FunctionName("<your_function_name>")]
public static async Task<string> <your_function_name>(<your_function_trigger>,
[Dynamics365Output("%<your_dynamics_365_connection_string>%", ContinueOnError = false)] IAsyncCollector<OrganizationRequest> requests, 
ILogger log)
{
    log.LogInformation($"Function triggered");
    
    Microsoft.Xrm.Sdk.Entity bpi= new Microsoft.Xrm.Sdk.Entity("sgs_batchphoneinput");
    bpi["sgs_name"] = "Test Phone Batch";
    CreateRequest req = new CreateRequest();
    req.Target = bpi;
        
    await requests.AddAsync(req);
    return "done!";
}
```

The sample above shows a CreateRequest, and you can do any requests derived from OrganizationRequest.  As for connection string, please refer to https://docs.microsoft.com/en-us/powerapps/developer/data-platform/xrm-tooling/use-connection-strings-xrm-tooling-connect.  In particular, if you are using service account, please following OAuth section; if you are using client secret please follow Client Secret section.

### Input / output Binding Usage

If all you need more complicated stuff than just to send some commands to Dyancmis 365, Dyanmics 365 Input / Output Binding can be used as below

```sh
[FunctionName("<your_function_name>")]
public static string <your_function_name>(<your_function_trigger>,
[Dynamics365Client("%<your_dynamics_365_connection_string>%")] ServiceClient client,
ILogger log)
{
    log.LogInformation($"Function triggered");
    using(client) {
        // your actions with Dynamics 365
    }
    return "done!";
}
```

For Dynamics 365 connection string, please refer to the previous section for more details.  For how to user ServiceClient, please refer to https://www.nuget.org/packages/Microsoft.PowerPlatform.Dataverse.Client/

## License

Free software, absolutely no warranty, use at your own risk!
