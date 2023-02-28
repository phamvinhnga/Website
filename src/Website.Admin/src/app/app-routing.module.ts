import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './module/login/login.component';

const routes: Routes = [
  {
    path: 'cms',
    component: AppComponent,
    loadChildren: () =>
      import('./module/cms/cms.module').then((m) => m.CmsModule),
  },
  {
    path: 'dang-nhap',
    component: LoginComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    initialNavigation: 'enabledBlocking'
})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
