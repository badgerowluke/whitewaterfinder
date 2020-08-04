import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { User } from '../model/authuser'
import { RiverUserSerice } from '../services/river-user.service';
import { RiverUserPreference } from '../model/riveruserreference';
@Component({
    selector: 'app-favorites',
    templateUrl:'favorites.component.html',
    styleUrls:[]
})
export class FavoritesComponent implements OnInit {
    
    private user: User;
    userFavorites: RiverUserPreference[];
    constructor(public auth: AuthService,
                private riverUsers: RiverUserSerice) {}

    ngOnInit() {
        this.user = this.riverUsers.getActiveUser();
        console.log(this.user)
        this.riverUsers.getUserFavorites(this.user.sub).then((response) => {
            this.userFavorites = response;
            console.log(this.userFavorites)
        })
    }
}