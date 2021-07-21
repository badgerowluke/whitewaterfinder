import { Injectable } from "@angular/core";

@Injectable()
export class BootstrapConfig {
  auth: AuthenticationConfig;
  insights:Insights;
  backend:Backend;

  production:boolean;

}
class AuthenticationConfig {
  clientId: string;
  domain: string;
}
class Insights {
  instrumentationKey:string
}
class Backend {
  apiUrl:string;
}


