import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IAuthModel } from '../shared/model/auth.model';
import { AuthService } from '../shared/service/auth.service';
import { Constants } from '../shared/common/constants';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  username:string | undefined;
  password:string | undefined;

  constructor(
    private readonly authService:AuthService,
    private readonly router:Router
  ) { 

  }

  onSubmit(){
    return this.authService.signIn({
      userName: this.username,
      password: this.password
    } as IAuthModel).subscribe(res => {
      this.authService.saveToken(res.accessToken, res.refreshToken);
      this.router.navigateByUrl('cms');
    })
  }
}
