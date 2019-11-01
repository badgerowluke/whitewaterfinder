import { AzureFunction, Context } from "@azure/functions"
import * as stuff from "../Core/RiverService"


const queueTrigger: AzureFunction = async function (context: Context, myQueueItem: string): Promise<void> {
    context.log('Queue trigger function processed work item', myQueueItem);

    const serve = new stuff.RiverService(process.env["blobStore"]);
    serve.postToStorage(myQueueItem)
};

export default queueTrigger;
