import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { environment } from "src/environments/environment";
import { AuthService } from "../auth/auth.service";
import { RiverUserPreference } from "../model/riveruserreference";

@Injectable()
export class RiverUserSerice {
    private activeUser;
    constructor(private http: Http, 
                private auth: AuthService) {
        this.auth.userProfile$.subscribe(
            value => this.activeUser = value,
            err => console.error(err)
        )
    }

    getActiveUser: () => any = () => {

        return this.activeUser;
    }
    
    postUserFavorite: (preference:RiverUserPreference) => Promise<Response> = (preference:RiverUserPreference) => {

        return this.http.post(environment.baseUrl + "/api/users", preference)
        .map((response:Response) => response.json()).toPromise();
    }

    getUserFavorites: (sub:string) => Promise<RiverUserPreference[]> = (sub:string) => {
        return this.http.get(environment.baseUrl + `/api/users/${sub}`)
        .map((response:Response) => <RiverUserPreference[]> response.json()).toPromise();
    }
}