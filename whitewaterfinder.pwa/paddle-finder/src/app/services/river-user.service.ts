import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { AuthService } from "./auth/auth.service";
import { RiverUserPreference } from "../model/riveruserreference";

@Injectable()
export class RiverUserSerice {
    private activeUser;

    private headers = new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Ocp-Apim-Subscription-Key', environment.subscriptionKey);
    
    constructor(private http: HttpClient, 
                private auth: AuthService) {
        this.auth.userProfile$.subscribe(
            value => this.activeUser = value,
            err => console.error(err)
        )
    }

    getActiveUser: () => any = () => {

        return this.activeUser;
    }
    
    postUserFavorite: (preference:RiverUserPreference) => any = (preference:RiverUserPreference) => {

        return this.http.post(environment.baseUrl + "/api/users", preference, {headers: this.headers}).toPromise();

    }

    getUserFavorites: (sub:string) => Promise<RiverUserPreference[]> = (sub:string) => {
        return this.http.get<RiverUserPreference[]>(environment.baseUrl + `/api/users/${sub}`, {headers: this.headers}).toPromise();

    }
}