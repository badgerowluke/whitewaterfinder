import { HttpClient, HttpHeaders } from '@angular/common/http';


export class BaseService {
    protected http:HttpClient;
    protected headers: HttpHeaders;
    
    constructor(httpClient:HttpClient) {
        this.http = httpClient;
    }




}