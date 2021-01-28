
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { shareReplay } from 'rxjs/operators';

import { HttpClient } from '@angular/common/http';
import { EnvironmentService } from '../environments/environment.service';

@Injectable({ providedIn: 'root'})
export class AppInitService {
    private readonly CONFIG_URL = "assets/config/config.json"
    private config$: Observable<any>;

    constructor(private http:HttpClient, private environmentService:EnvironmentService) { }

    loadConfiguration() {
        this.config$ = this.http.get(this.CONFIG_URL).pipe(shareReplay(1))
        this.environmentService.setEnvironment(this.config$)
        return this.config$

    }


}