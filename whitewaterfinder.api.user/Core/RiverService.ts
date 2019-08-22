import {TableService, QueueService, ExponentialRetryPolicyFilter, createTableService, 
    createQueueService, TableUtilities, TableQuery } from "azure-storage";
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
    getFromStorage  = async (name:string): Promise<any> =>{
        var query = new TableQuery()
        .where('PartitionKey eq ?', name);

        var continuation = null;
        return new Promise(async (resolve, reject) =>{
            await this.service.queryEntities("UserPreferences", query, continuation, (error, result, response) =>{
                if(error) {
                    reject(error);
                }
        
                resolve(result.entries);
                
            })
        })
    }

    private entityResolver = (entity) =>{
        let resolvedEntity = {};
        for(let key in entity) {
            resolvedEntity[key] = entity[key]._
        }
        return resolvedEntity;
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