import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { AppSettingsApiService } from 'src/app/api-services/appsettings-api.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
  festivalName = environment.festivalName;

  username: string;
  isAuthenticated = false;

  constructor(
    private appSettingsApiService: AppSettingsApiService,
    private oidcSecurityService: OidcSecurityService
  ) {}

  ngOnInit(): void {
    this.appSettingsApiService
      .getSettings()
      .subscribe(
        (appsettings) =>
          (this.festivalName =
            appsettings.festivalName ?? environment.festivalName)
      );

    this.oidcSecurityService.isAuthenticated$.subscribe(
      (isAuthenticated: boolean) => {
        this.isAuthenticated = isAuthenticated;
      }
    );

    this.oidcSecurityService.userData$.subscribe((userData) => {
      this.username = userData?.name;
    });
  }

  logout(): void {
    this.oidcSecurityService.logoff();
  }
}
