import { RiverDataService } from '../services/river-data.service';
import { Component } from '@angular/core';
import { River } from '../model/river';
import * as _ from 'lodash';
import { AuthService } from '../services/auth/auth.service';
@Component({
    selector: 'app-river-list',
    templateUrl: 'river-list.component.html',
    styleUrls: ['river-list.component.scss']
})
export class RiverListComponent {
    searchValue = '';
    rivers: any[];
    data: River[]
    constructor(private riverData: RiverDataService, private auth: AuthService) { }
    findRivers: (value: any) => void = (value: any) => {

        if(value.keyCode in [8, 46] )
        {

        } else {
            const search = this.searchValue;

            this.riverData.getAllUSRivers(search).then((response) =>{
                this.rivers = response;
            })


        }        
    }
}
