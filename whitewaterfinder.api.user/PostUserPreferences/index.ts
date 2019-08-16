import { AzureFunction, Context, HttpRequest } from "@azure/functions"
import * as azure from  "azure-storage";


const httpTrigger: AzureFunction = async function (context: Context, req: HttpRequest): Promise<void> {
    context.log('HTTP trigger function processed a request.');
    const name = (req.query.name || (req.body && req.body.name));
    

    var retryOptions = new azure.ExponentialRetryPolicyFilter();

    var queueService = azure.createQueueService(process.env["blob-store"]).withFilter(retryOptions);
    queueService.createQueueIfNotExists("user-preference-queue", (error, results, response)=>{
        if(!error) {
            console.log("queue created");
        }
        return;

    });
    queueService.createMessage("user-preference-queue", Buffer.from(JSON.stringify(req.body)).toString('base64'), (error, results, response) =>{
        if(error) {
            console.log("something went wrong");
        }
    });

    if (name) {
        context.res = {
            // status: 200, /* Defaults to 200 */
            body: "Hello " + (req.query.name || req.body.name)
        };
    }
    else {
        context.res = {
            status: 400,
            body: "Please pass a name on the query string or in the request body"
        };
    }
};

export default httpTrigger;
