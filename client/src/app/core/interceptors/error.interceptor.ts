import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(
    private router: Router,
    private toastrService: ToastrService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error) {
          if (error.status === 400) {
            //checking if there are any validation errors - they usually come in an array
            if (error.error.errors) {
              throw error.error;
            } else {
              this.toastrService.error(error.error.message, error.status.toString())
            }
          }
          if (error.status === 401) {
            this.toastrService.error(error.error.message, error.status.toString())
          }

          if (error.status === 404) {
            this.router.navigateByUrl('/not-found');
          }

          if (error.status === 500) {
            this.router.navigateByUrl('/server-error');
          }
        }

        return throwError(() => new Error(error.message));
      })
    );
  }
}
