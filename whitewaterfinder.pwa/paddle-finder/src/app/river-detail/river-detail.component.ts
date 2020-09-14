import { Component, OnInit,  NgZone, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { River } from '../model/river';
import { RiverUserPreference } from '../model/riveruserreference';
import { RiverDataService } from '../services/river-data.service';
import { ActivatedRoute } from '@angular/router';

import * as _ from 'lodash';

import { RiverUserSerice } from '../services/river-user.service';
import { AuthService } from '../services/auth/auth.service';
import { User } from '../model/authuser';
import { Observable, Subscription } from 'rxjs';
@Component({
    selector: 'app-river-detail',
    templateUrl: 'river-detail.component.html',
    styleUrls: ['river-detail.component.scss']
})
export class RiverDetailComponent implements OnInit, OnDestroy {
    riverCode: string;
    river: River;
    point: any;
    user: User;
    profile: Subscription;
    isFavorite: boolean = false;
    
    constructor(private route: ActivatedRoute, 
                private riverData: RiverDataService,
                private riverUser: RiverUserSerice,
                public auth: AuthService) {

    }
    ngOnInit() {

        this.riverCode = this.route.snapshot.params['id'];
        this.point = this.route.snapshot.queryParams;
        this.pullRiverDetails(this.riverCode);
        this.user = this.riverUser.getActiveUser();
        this.profile = this.auth.userProfile$.subscribe(user => {
            if(user) {
                this.checkRiverFavorites(user.sub);
            }

        })
    }
    ngOnDestroy() {
        this.profile.unsubscribe();
    }

    getLatitude() {
        return this.river.latitude;
    }

    pullRiverDetails: (riverCode: string) => River = (riverCode: string) => {
        let thisRiver: River;
        this.riverData.getRiverDetails(riverCode).then((data) => {

            thisRiver = data;
            const vals = _.each(thisRiver.riverData, (r) => {
                r.dateTime = new Date(r.dateTime);
            });
            const vals2 = _.orderBy(thisRiver.riverData, ['dateTime'], ['desc']);

            thisRiver.riverData = vals2;
            this.river = thisRiver;

        });
        
        return thisRiver;
    }

    saveRiverAsFavorite: () => void =() => {
        
        if(!this.user) {
            alert("please log in")
        } else {
            const pref = new RiverUserPreference();
            pref.sub = this.user.sub;
            pref.riverName = this.river.name;
            pref.riverId= this.river.riverId;
            pref.lastFlow = this.river.riverData[0].flow;
            pref.lastLevel = this.river.riverData[0].level;
            pref.lastReported = this.river.riverData[0].dateTime;

            this.riverUser.postUserFavorite(pref).then((data) => {});
        }  
    }
    
    checkRiverFavorites: (userId: string) => void = (userId: string) => {
        this.riverUser.getUserFavorites(userId).then((data) =>{
            data.forEach((i) => {
                if(i.riverId === this.riverCode) {
                    this.isFavorite = true;
                }
            })
        })
    }
}
