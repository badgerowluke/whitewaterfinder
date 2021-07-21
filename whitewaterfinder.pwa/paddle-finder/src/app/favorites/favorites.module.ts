import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FavoritesComponent } from "./favorites.component";
import { RouterModule } from '@angular/router';

@NgModule({
    declarations:[
        FavoritesComponent
    ],
    imports:[
        CommonModule,
        RouterModule
    ],
    providers: [],
    exports:[]
})
export class FavoritesComponentModule {}