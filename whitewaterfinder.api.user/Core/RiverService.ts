import {TableService, QueueService, ExponentialRetryPolicyFilter, createTableService,createQueueService, TableUtilities } from "azure-storage";
import * as uuidv1 from 'uuid/v1';
export class RiverService {
    private service: TableService;
    private queue: QueueService;

    constructor(private connectionString:string) {
        const retryOptions = new ExponentialRetryPolicyFilter();
        this.service = createTableService(connectionString).withFilter(retryOptions);
        this.queue = createQueueService(connectionString).withFilter(retryOptions);
        
    }
    postToStorage: (myQueueItem:string) => void = (myQueueItem:string) => {
        this.service.createTableIfNotExists("UserPreferences", (error) =>{
            if(error) {
                console.log(error);
                throw new Error("oops");
            }
            return;
        });

        let entGen = TableUtilities.entityGenerator;
        let pref = {
            PartitionKey: entGen.String(myQueueItem["name"]),
            RowKey: entGen.String(uuidv1()),
            FavoriteRiver: entGen.String(myQueueItem["favoriteRiver"])
        };
        this.service.insertOrMergeEntity("UserPreferences",pref, (error, result, response) =>{
            if(error) {
                console.log(error);
                throw new Error("uh-oh");
            }
        })        

    }
    getFromStorage  = async(): Promise<any> =>{
        return null;
    }
    postToQueue = (record:any) =>  {
        this.queue.createQueueIfNotExists("user-preference-queue", (error, results, response)=>{
            if(!error) {
                console.log("queue created");
            }
            return;
    
        });
        this.queue.createMessage("user-preference-queue", Buffer.from(JSON.stringify(record)).toString('base64'), (error, results, response) =>{
            if(error) {
                console.log("something went wrong");
            }
        });
    }


}