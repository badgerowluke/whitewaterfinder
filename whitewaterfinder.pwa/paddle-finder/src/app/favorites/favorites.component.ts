import { Component, OnInit } from '@angular/core';
@Component({
    selector: 'app-favorites',
    templateUrl:'favorites.component.html',
    styleUrls:[]
})
export class FavoritesComponent implements OnInit {
    ngOnInit()
    {
        console.log(history.state.data);
    }
}