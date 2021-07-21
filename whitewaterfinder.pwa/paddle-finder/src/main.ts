import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { BootstrapConfig } from 'pf-components';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';


fetch('assets/config/config.json')
.then((response)=> response.json())
.then(config => {

  if (environment.production) {
    enableProdMode();
  }
  
  platformBrowserDynamic([{provide: BootstrapConfig, useValue:config}])
  .bootstrapModule(AppModule)
    .catch(err => console.error(err));
})

