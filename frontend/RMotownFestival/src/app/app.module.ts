import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { AuthModule, OidcConfigService, LogLevel, OidcSecurityService } from 'angular-auth-oidc-client';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutModule } from './layout/layout.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './auth.interceptor';
import { AuthorizationGuard } from './authorization.guard';

export function configureAuth(oidcConfigService: OidcConfigService) {
  return () =>
    oidcConfigService.withConfig({
            stsServer: 'https://login.microsoftonline.com/a8ad445d-cb71-4d2b-bedd-f4dd8fee406e',
            authWellknownEndpoint: 'https://login.microsoftonline.com/a8ad445d-cb71-4d2b-bedd-f4dd8fee406e/v2.0/.well-known/openid-configuration',
            redirectUrl: window.location.origin,
            postLogoutRedirectUri: window.location.origin,
            clientId: '9826b4a1-6787-4e49-8002-e13f62fcd325',
            scope: 'openid profile api://e56f3a70-79a6-48ed-824d-6adb1c1d75ab/Pictures.Upload.All',
            responseType: 'code',
            maxIdTokenIatOffsetAllowedInSeconds: 600,
            issValidationOff: true, // this needs to be true if using a common endpoint in Azure
            autoUserinfo: false,
            silentRenew: true,
            silentRenewUrl: window.location.origin + '/silent-renew.html',
            logLevel: LogLevel.Debug
    });
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,

    HttpClientModule,

    LayoutModule,

    AuthModule.forRoot(),
  ],
  providers: [
    OidcSecurityService,
    OidcConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: configureAuth,
      deps: [OidcConfigService],
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
    AuthorizationGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
