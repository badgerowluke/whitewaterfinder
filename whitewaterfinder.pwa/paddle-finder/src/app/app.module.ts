import { BrowserModule } from '@angular/platform-browser';

import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { RiverDataService } from './services/river-data.service';
import { RiverUserSerice } from './services/river-user.service';
import { AppRoutingModule, routableComponents } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { ProfileComponent } from './profile/profile.component';
import 'rxjs';




@NgModule({
  declarations: [
    AppComponent,
    routableComponents,
    ProfileComponent
  ],
  imports: [
    BrowserModule,

    AppRoutingModule,
    HttpClientModule,
    FormsModule,

    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  providers: [RiverDataService, RiverUserSerice],
  bootstrap: [AppComponent]
})
export class AppModule { }
