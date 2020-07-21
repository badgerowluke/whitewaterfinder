import { AzureFunction, Context, HttpRequest } from "@azure/functions"
import { RiverService } from "../Core/RiverService";


const httpTrigger: AzureFunction = async function (context: Context, req: HttpRequest): Promise<void> {
    context.log('HTTP trigger function processed a request.');

    
    let service = new RiverService(process.env["blobStore"]);
    service.postToQueue(req.body);
};

export default httpTrigger;
