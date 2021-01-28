import { BrowserModule } from '@angular/platform-browser';

import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { RiverDataService } from './services/river-data.service';
import { RiverUserSerice } from './services/river-user.service';
import { AppRoutingModule, routableComponents } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { ProfileComponent } from './profile/profile.component';
import { AppInitService } from './app-init.service';
import 'rxjs';
import { EnvironmentService } from 'src/environments/environment.service';

import { interceptors } from './interceptors'


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
  providers: [
    RiverDataService, 
    RiverUserSerice,
    EnvironmentService,
    {
      provide: APP_INITIALIZER,
      useFactory: (appInit: AppInitService) => () => appInit.loadConfiguration().toPromise(),
      deps: [AppInitService, EnvironmentService],
      multi: true
    },
    interceptors
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
