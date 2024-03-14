import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { AccountService } from '../../account/account.service';
import { Observable, take } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class jwtInterceptor implements HttpInterceptor {

  constructor(private accountService: AccountService){}

  intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.accountService.user$.pipe(take(1)).subscribe({
      next: user => {
        if(user){
          req = req.clone({
            setHeaders: {
              Authorization: 'Bearer ' + user?.jwt
            }
          });
        }      
      }
    })
    return next.handle(req);
  } 
}
