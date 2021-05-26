import {
    TableService, QueueService, ExponentialRetryPolicyFilter, createTableService, 
    createQueueService, TableUtilities, TableQuery 
} from "azure-storage";

import * as uuidv1 from 'uuid/v1';

export class RiverService {
    private service: TableService;
    private queue: QueueService;

    constructor(private connectionString:string) {
        const retryOptions = new ExponentialRetryPolicyFilter();
        this.service = createTableService(connectionString).withFilter(retryOptions);
        this.queue = createQueueService(connectionString).withFilter(retryOptions);
        
    }
    private generateEntity(myQueueItem:string) {
        let entGen = TableUtilities.entityGenerator;
        let pref = {
            PartitionKey: entGen.String(myQueueItem["sub"].toString()),
            RowKey: entGen.String(myQueueItem["riverId"]),
            RiverName: entGen.String(myQueueItem["riverName"]),
            RiverId: entGen.String(myQueueItem["riverId"]),
            LastFlow: entGen.String(myQueueItem["lastFlow"]),
            LastLevel: entGen.String(myQueueItem["lastLevel"]),
            LastReported: entGen.DateTime(myQueueItem["lastReported"])
        };
        return pref;
    }
    
    postToStorage = async (myQueueItem:string): Promise<void> => {
        try {
            let doesExist: boolean;
            this.service.createTableIfNotExists("UserPreferences", (error, result) => {
                if(error) {
                    console.log(error);
                    throw new Error("oops");
                }
                doesExist = result.exists
                return;
            });
            let pref = this.generateEntity(myQueueItem);
    
    
            this.service.insertOrMergeEntity("UserPreferences",pref, (error, result, response) => {
                if(error) {
                    console.log(error);
                    throw new Error("uh-oh");
                }
            })        

        } catch(e) {
            throw e
        }

    }

    getFromStorage  = async (name:string): Promise<any> => {
        var query = new TableQuery()
        .where('PartitionKey eq ?', name);


        var continuation = null;
        return new Promise(async (resolve, reject) => {
            await this.service.queryEntities("UserPreferences", query, continuation, (error, result, response) => {
                if(error) {
                    reject(error);
                }
        
                resolve(result.entries);
                
            })
        })
    }

    removeFromStorage = async (myQueueItem:string): Promise<any> => {
        let pref = this.generateEntity(myQueueItem);
        this.service.deleteEntity("UserPreferences",pref, (error) => {
            if(error) {
                throw new Error("uh-oh")
            }

        })
    }
    
    postToQueue = async (record:any, queue:string) =>  {

        this.queue.createMessage(queue, Buffer.from(JSON.stringify(record)).toString('base64'), (error, results, response) => {
            if (error) {
                console.log("something went wrong");
            }
        });
    }
}