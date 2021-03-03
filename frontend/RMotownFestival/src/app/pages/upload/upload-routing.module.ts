import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizationGuard } from 'src/app/authorization.guard';
import { UploadComponent } from './upload.component';

const routes: Routes = [
  { path: '', component: UploadComponent,  canActivate: [AuthorizationGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UploadRoutingModule { }
