import { AzureFunction, Context, HttpRequest } from "@azure/functions"
import { RiverService } from "../Core/RiverService";


const httpTrigger: AzureFunction = async function (context: Context, req: HttpRequest): Promise<void> {

    let service = new RiverService(process.env["blobStore"]);

    if(req.method === "POST") {
        service.postToQueue(req.body, "user-preference-queue");
    }

    if(req.method === "DELETE") {
        service.postToQueue(req.body,"drop-user-pref-queue");
    }
};

export default httpTrigger;
