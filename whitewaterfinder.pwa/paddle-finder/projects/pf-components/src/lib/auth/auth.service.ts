import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { AuthService } from '@auth0/auth0-angular'

import { EnvironmentService } from "../environments/environment.service";

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    user$: Observable<any> = this.auth.user$

    //TODO: In the past I've used this service to POST new user registration information does it need to happen here too
    constructor(private auth: AuthService, private env: EnvironmentService) {}

    loginWithRedirect(): Observable<void> {
        return (this.auth.loginWithRedirect())
    }

    logout(): void {
        this.auth.logout( { returnTo: window.location.origin } )
    }
}