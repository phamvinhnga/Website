import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpInterceptor,
    HttpEvent,
    HttpErrorResponse,
} from '@angular/common/http';
import { AuthService } from '../module/shared/service/auth.service';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError, filter, switchMap, take } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(
        private authService: AuthService
    ) { }

    intercept(request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>> {
        const token = this.authService.getToken();
        let header:any = {
          'Access-Control-Allow-Origin': '*'
        }
        if (token) {
          header.Authorization = `Bearer ${token}`;
            request = request.clone({
                setHeaders: header,
            });
        }
        return next.handle(request).pipe(
            catchError((error: HttpErrorResponse) => {
              if (error.status === 401) {
                return this.authService.refreshToken().pipe(
                  switchMap((res) => {
                    this.authService.saveToken(res.accessToken, res.refreshToken);
                    request = request.clone({
                      setHeaders: {
                        Authorization: `Bearer ${this.authService.getToken()}`,
                        'Access-Control-Allow-Origin': '*'
                      }
                    });
                    return next.handle(request);
                  }),
                  catchError((err) => {
                    this.authService.logout();
                    return throwError(err);
                  })
                );
              }
              return throwError(error);
            })
        );
    }
}
