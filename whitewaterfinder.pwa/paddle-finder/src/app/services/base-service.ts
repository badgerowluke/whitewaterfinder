import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AKVSecret } from '../model/keyvault';
import { environment } from '../../environments/environment'

export class BaseService {
    protected http:HttpClient;
    protected headers: HttpHeaders;
    
    constructor(httpClient:HttpClient) {
        this.http = httpClient;
    }

    getAPIMSubscriptionKey: () => Promise<AKVSecret> = () => {
        return  this.http.get<AKVSecret>(environment.baseUrl + '/api/configure').toPromise();
    }



}