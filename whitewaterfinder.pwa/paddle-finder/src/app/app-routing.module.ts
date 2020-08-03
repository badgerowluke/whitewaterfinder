import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { RiverListComponent } from './river-list/river-list.component';
import { RiverDetailComponent } from './river-detail/river-detail.component';
import { FavoritesComponent } from './favorites/favorites.component';
import { ProfileComponent } from './profile/profile.component';
const routes: Routes = [
    { path: '', pathMatch: 'full', component: RiverListComponent },
    { path: 'river/:id', component: RiverDetailComponent },
    { path: 'favorites', component: FavoritesComponent },
    { path: 'profile', component: ProfileComponent },
    { path: '**', pathMatch: 'full', redirectTo: ''}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}

export const routableComponents = [
    RiverListComponent,
    RiverDetailComponent,
    FavoritesComponent
];
