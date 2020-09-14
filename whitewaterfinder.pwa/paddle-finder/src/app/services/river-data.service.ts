import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { River } from '../model/river';
import { AKVSecret } from '../model/keyvault'
import { environment } from '../../environments/environment';




@Injectable()
export class RiverDataService {

    private headers: HttpHeaders; 

    constructor(private http: HttpClient) {
        if(!environment.subscriptionKey) {
            console.error("no api key")


            this.http.get<AKVSecret>("http://localhost:7071/api/configure").toPromise()
            .then((response) => {

                environment.subscriptionKey = response.value;
                this.headers = new HttpHeaders()
                .set('content-type', 'application/json')
                .set('Ocp-Apim-Subscription-Key', response.value);
            
            });
        }

    }
    getAllUSRivers: (partialName: string) => Promise<River[]> = (partialName: string) => {

        
        if(!partialName) {
            return this.http.get<River[]>(environment.apiUrl + "/Rivers/rivers", {headers: this.headers} ).toPromise();

        } else {
            return this.http.get<River[]>(environment.apiUrl + '/Rivers/rivers?name=' + partialName, {headers: this.headers}).toPromise();

        }
    }
    getRiverDetails: (riverCode: string) => Promise<River> = (riverCode: string) => {
        return this.http.get<River>(environment.apiUrl + '/Rivers/details/' + riverCode, {headers: this.headers}).toPromise();

    }
}

