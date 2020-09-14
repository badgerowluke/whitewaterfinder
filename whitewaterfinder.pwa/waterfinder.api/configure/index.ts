import { AzureFunction, Context, HttpRequest } from "@azure/functions"
import { DefaultAzureCredential } from '@azure/identity';
import { SecretClient } from '@azure/keyvault-secrets';

const credential = new DefaultAzureCredential();



const httpTrigger: AzureFunction = async function (context: Context, req: HttpRequest): Promise<void> {
    context.log('HTTP trigger function processed a request.');

    const client = new SecretClient(`https://${process.env["vaultName"]}.vault.azure.net/`, credential); 

    var secret = await client.getSecret("paddle-finder-api-key")

    context.res = {
        // status: 200, /* Defaults to 200 */
        body: secret
    };

};

export default httpTrigger;