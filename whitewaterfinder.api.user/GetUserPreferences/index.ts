import { AzureFunction, Context, HttpRequest } from "@azure/functions"
import * as azure from "azure-storage";


const httpTrigger: AzureFunction = function (context: Context, req: HttpRequest): any {
    context.log('HTTP trigger function processed a request.');
    const name = (req.query.name || (req.body && req.body.name));

    var query = new azure.TableQuery()
        .where('PartitionKey eq ?', name);

    queryTable('UserPreferences', query).then((entities)=>{
        
        if(Array.isArray(entities)) {
            let returns = [];
            entities.forEach((e)=>{
                let val = entityResolver(e);
                console.log(val)
                returns.push(val)
            })
            context.res ={ 
                body: returns
            }
            context.done();

        }
        context.res = {
            body: entities
        };

        context.done();
        
    })


};
const queryTable = async function(table, tableQuery){
    var retryOptions = new azure.ExponentialRetryPolicyFilter();
    var tableService = azure.createTableService(process.env["blob-store"]).withFilter(retryOptions);
    var continuation = null;
    return new Promise(async (resolve, reject) =>{
        await tableService.queryEntities(table, tableQuery, continuation, (error, result, response) =>{
            if(error) {
                reject(error);
            }
    
            resolve(result.entries);
            
        })
    })
}
const entityResolver = function(entity){
    let resolvedEntity = {};
    for(let key in entity) {
        resolvedEntity[key] = entity[key]._
    }
    return resolvedEntity;
}

export default httpTrigger;
