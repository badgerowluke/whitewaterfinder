import { AzureFunction, Context } from "@azure/functions"
import * as stuff from "../Core/RiverService"


const queueTrigger: AzureFunction = async function (context: Context, myQueueItem: string): Promise<void> {
    const serve = new stuff.RiverService(process.env["blobStore"]);
    serve.removeFromStorage(myQueueItem).catch(e => console.error(e));
};

export default queueTrigger;
