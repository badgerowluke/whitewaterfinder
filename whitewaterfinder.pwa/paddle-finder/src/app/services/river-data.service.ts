import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { River } from '../model/river';
import { environment } from '../../environments/environment';




@Injectable()
export class RiverDataService {
    constructor(private http: Http) {}
    getAllUSRivers: (partialName: string) => Promise<River[]> = (partialName: string) => {
        if(!partialName) {
            return this.http.get(environment.baseUrl + "/api/rivers?code=" + environment.riverKeyCode)
            .map((response: Response) => <River[]>response.json()).toPromise();
        } else {
            return this.http.get(environment.baseUrl + '/api/rivers?name=' + partialName + "&code=" + environment.riverKeyCode)
            .map((response: Response) => <River[]>response.json()).toPromise();
        }
    }
    getRiverDetails: (riverCode: string) => Promise<River> = (riverCode: string) => {
        return this.http.get(environment.baseUrl + '/api/rivers/details/' + riverCode + "?code=" + environment.detailsKeyCode)
        .map((response: Response) => <River>response.json()).toPromise();
    }
}

