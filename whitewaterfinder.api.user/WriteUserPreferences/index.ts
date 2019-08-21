import { AzureFunction, Context } from "@azure/functions"
import * as azure from "azure-storage";
import * as uuidv1 from 'uuid/v1';

import * as stuff from "../Core/RiverService"


const queueTrigger: AzureFunction = async function (context: Context, myQueueItem: string): Promise<void> {
    context.log('Queue trigger function processed work item', myQueueItem);

    let retryOptions = new azure.ExponentialRetryPolicyFilter();
    const serve = new stuff.RiverService();
    let tableService = azure.createTableService(process.env["blob-store"]).withFilter(retryOptions);
    tableService.createTableIfNotExists("UserPreferences", (error, result, response) => {
        if(error) {
            console.log(error);
            throw new Error("oops");
        }
        return;
    });

    let entGen = azure.TableUtilities.entityGenerator;
    let pref = {
        PartitionKey: entGen.String(myQueueItem["name"]),
        RowKey: entGen.String(uuidv1()),
        FavoriteRiver: entGen.String(myQueueItem["favoriteRiver"])
    };
    tableService.insertOrMergeEntity("UserPreferences",pref, (error, result, response) =>{
        if(error) {
            console.log(error);
            throw new Error("uh-oh");
        }
    })
};

export default queueTrigger;
