import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { environment } from 'src/environments/environment';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  //we only want to protect the pictures route -> we send only our access token for that route
  private secureRoutes = [environment.apiBaseUrl + 'pictures'];

  constructor(private oidcSecurityService: OidcSecurityService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ) {
    if (!this.secureRoutes.find((x) => request.url.startsWith(x))) {
      return next.handle(request);
    }

    const token = this.oidcSecurityService.getToken();

    if (!token) {
      return next.handle(request);
    }

    request = request.clone({
      headers: request.headers.set('Authorization', 'Bearer ' + token),
    });

    return next.handle(request);
  }
}
