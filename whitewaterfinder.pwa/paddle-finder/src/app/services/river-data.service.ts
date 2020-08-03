import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { River } from '../model/river';
import { environment } from '../../environments/environment';




@Injectable()
export class RiverDataService {
    constructor(private http: HttpClient) {}
    getAllUSRivers: (partialName: string) => Promise<River[]> = (partialName: string) => {
        if(!partialName) {
            return this.http.get<River[]>(environment.baseUrl + "/api/rivers?code=" + environment.riverKeyCode).toPromise();

        } else {
            return this.http.get<River[]>(environment.baseUrl + '/api/rivers?name=' + partialName + "&code=" + environment.riverKeyCode).toPromise();

        }
    }
    getRiverDetails: (riverCode: string) => Promise<River> = (riverCode: string) => {
        return this.http.get<River>(environment.baseUrl + '/api/rivers/details/' + riverCode + "?code=" + environment.detailsKeyCode).toPromise();

    }
}

