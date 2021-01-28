import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { CacheInterceptor } from './cache-control.interceptor';
import { SubscriptionHeaderInterceptor } from './subscription-key.interceptor'



export const interceptors = [
    { provide: HTTP_INTERCEPTORS, useClass: SubscriptionHeaderInterceptor, multi:true },
    { provide: HTTP_INTERCEPTORS, useClass: CacheInterceptor, multi:true },

]