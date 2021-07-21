import { HttpHandler,
    HttpInterceptor,
    HttpRequest} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentService } from '../environments/environment.service';

@Injectable()
export class SubscriptionHeaderInterceptor implements HttpInterceptor {

    constructor(private env: EnvironmentService ) { }
    intercept(req: HttpRequest<any>, next: HttpHandler) {

        if(this.isReqWhiteListed(req.url)) {

            const key = this.env.environment != null ? this.env.environment.subscriptionKey : null;
            console.log(this.env.environment)
            if(key != null) {
                const newReq = req.clone({
                    headers: req.headers.set('content-type', 'application/json')
                    .set('Ocp-Apim-Subscription-Key', this.env.environment.subscriptionKey)
                });
                return next.handle(newReq);
            }
        }
        return next.handle(req);
    }
    private isReqWhiteListed(requestUrl: string): boolean {
        let positionIndicator: string = 'api/';
        let position = requestUrl.indexOf(positionIndicator);
        if (position > 0) {
            return true;
        //   let destination: string = requestUrl.substr(position + positionIndicator.length);
        //   for (let address of this.apiWhiteList) {
        //     if (new RegExp(address).test(destination)) {
        //       return true;
        //     }
        //   }
        }
        return false;
      }
}