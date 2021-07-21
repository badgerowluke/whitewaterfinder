
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { BootstrapConfig } from '../configuration/app.config'


@Injectable()
export class EnvironmentService 
{
    private dynamicEnv: any;
    constructor(private config: BootstrapConfig) { }
    get environment() { return this.dynamicEnv }

    get apiUrl() {
        if(this.config.production) {
            return this.dynamicEnv.backend.apiUrl;
        }
        return window.location.origin;
    }

    setEnvironment(env: any) {
        this.dynamicEnv = this.config
    }
}
