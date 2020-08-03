import { Component, OnInit,  NgZone, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { River } from '../model/river';
import { RiverUserPreference } from '../model/riveruserreference';
import { RiverDataService } from '../services/river-data.service';
import { ActivatedRoute } from '@angular/router';

import * as _ from 'lodash';

import { RiverUserSerice } from '../services/river-user.service';
@Component({
    selector: 'app-river-detail',
    templateUrl: 'river-detail.component.html',
    styleUrls: ['river-detail.component.scss']
})
export class RiverDetailComponent implements OnInit, OnDestroy {
    riverCode: string;
    river: River;
    point: any;

    
    constructor(private route: ActivatedRoute, 
                private riverData: RiverDataService,
                private riverUser: RiverUserSerice) {

    }
    ngOnInit() {

        this.riverCode = this.route.snapshot.params['id'];
        this.point = this.route.snapshot.queryParams;
        this.pullRiverDetails(this.riverCode);
    }
    ngOnDestroy() {
        //TODO
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
        let user = this.riverUser.getActiveUser();
        if(!user) {
            alert("please log in")
        } else {
            const pref = new RiverUserPreference();
            pref.sub = user.sub;
            pref.riverName = this.river.name;
            pref.riverId= this.river.riverId;
            pref.lastFlow = this.river.riverData[0].flow;
            pref.lastLevel = this.river.riverData[0].level;
            pref.lastReported = this.river.riverData[0].dateTime;

            this.riverUser.postUserFavorite(pref).then((data) => {
                console.log(data);
            });
        }

        
    }
}
