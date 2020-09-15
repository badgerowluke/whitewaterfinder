import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { AuthService } from "./auth/auth.service";
import { RiverUserPreference } from "../model/riveruserreference";
import { BaseService } from './base-service';

@Injectable()
export class RiverUserSerice extends BaseService {

    private activeUser;
    
    constructor(http: HttpClient, 
                private auth: AuthService) {
        super(http);
        
        if(!environment.subscriptionKey) {
            this.getAPIMSubscriptionKey()
            .then((response) => {
                this.setAPIMHeader(response);
            })
        }
        this.auth.userProfile$.subscribe(
            value => this.activeUser = value,
            err => console.error(err)
        )
    }

    getActiveUser: () => any = () => {

        return this.activeUser;
    }
    
    postUserFavorite: (preference:RiverUserPreference) => any = (preference:RiverUserPreference) => {

        return this.http.post(environment.apiUrl + "/users", preference, {headers: this.headers}).toPromise();

    }

    getUserFavorites: (sub:string) => Promise<RiverUserPreference[]> = (sub:string) => {
        return this.http.get<RiverUserPreference[]>(environment.apiUrl + `/users/${sub}`, {headers: this.headers}).toPromise();

    }
}