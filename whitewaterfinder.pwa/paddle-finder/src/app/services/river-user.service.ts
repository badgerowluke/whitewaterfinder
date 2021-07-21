import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { AuthService } from "./auth/auth.service";
import { RiverUserPreference } from "../model/riveruserreference";
import { BaseService } from './base-service';
import { EnvironmentService } from "pf-components";

@Injectable()
export class RiverUserSerice extends BaseService {

    private activeUser;
    
    constructor(http: HttpClient, 
                private auth: AuthService,
                private env: EnvironmentService) {
        super(http);
        

        this.auth.userProfile$.subscribe(
            value => this.activeUser = value,
            err => console.error(err)
        )
    }

    getActiveUser: () => any = () => {

        return this.activeUser;
    }
    
    postUserFavorite: (preference:RiverUserPreference) => any = (preference:RiverUserPreference) => {

        return this.http.post(this.env.apiUrl + "/users", preference).toPromise();

    }

    getUserFavorites: (sub:string) => Promise<RiverUserPreference[]> = (sub:string) => {
        return this.http.get<RiverUserPreference[]>(this.env.apiUrl + `/users/${sub}`).toPromise();

    }
}