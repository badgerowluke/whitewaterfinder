
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable()
export class EnvironmentService 
{
    private dynamicEnv: any;
    constructor() { }
    get environment() { return this.dynamicEnv }

    setEnvironment(env: Observable<any>) {
        env.subscribe(data => {
            this.dynamicEnv = { ...data}
        });
    }
}