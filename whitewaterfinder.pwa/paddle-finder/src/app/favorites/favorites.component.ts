import { Component, OnInit } from '@angular/core';

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
    constructor(private riverUsers: RiverUserSerice) {}

    ngOnInit() {
        this.user = this.riverUsers.getActiveUser();
        
        this.riverUsers.getUserFavorites(this.user.sub).then((response) => {
            this.userFavorites = response;
            
        })
    }
}