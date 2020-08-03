import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { AuthService } from "../auth/auth.service";
import { RiverUserPreference } from "../model/riveruserreference";

@Injectable()
export class RiverUserSerice {
    private activeUser;
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

        return this.http.post(environment.baseUrl + "/api/users", preference).toPromise();

    }

    getUserFavorites: (sub:string) => Promise<RiverUserPreference[]> = (sub:string) => {
        return this.http.get<RiverUserPreference[]>(environment.baseUrl + `/api/users/${sub}`).toPromise();

    }
}