import { AzureFunction, Context, HttpRequest } from "@azure/functions"
import { RiverService } from "../Core/RiverService";


const httpTrigger: AzureFunction = function (context: Context, req: HttpRequest, subId:string): any {


    const serve = new RiverService(process.env["blobStore"]);

    serve.getFromStorage(decodeURIComponent(context.bindingData.subId)).then((entities) =>{
        if(Array.isArray(entities)) {
            let returns = [];
            entities.forEach((e)=>{
                let val = entityResolver(e);
                context.log(val)
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

const entityResolver = function(entity){
    let resolvedEntity = {};
    for(let key in entity) {
        resolvedEntity[key] = entity[key]._
    }
    return resolvedEntity;
}

export default httpTrigger;
