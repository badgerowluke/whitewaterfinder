import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { River } from '../model/river';
// import { environment } from '../../environments/environment';
import { BaseService } from './base-service'

import { EnvironmentService } from 'pf-components';


@Injectable()
export class RiverDataService extends BaseService {


    constructor(http:HttpClient, private env:EnvironmentService) {
        super(http);
    }

    getAllUSRivers: (partialName: string) => Promise<River[]> = (partialName: string) => {

        if(!partialName) {
            return this.http.get<River[]>(this.env.apiUrl + "/Rivers/rivers" ).toPromise();

        } else {
            return this.http.get<River[]>(this.env.apiUrl + '/Rivers/rivers?name=' + partialName).toPromise();

        }
    }
    getRiverDetails: (riverCode: string) => Promise<River> = (riverCode: string) => {
        return this.http.get<River>(this.env.apiUrl + `/Rivers/rivers/${riverCode}/details`).toPromise();

    }
}

