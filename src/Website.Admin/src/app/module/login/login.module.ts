import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    CommonModule,
    FormsModule,
    ButtonModule,
    InputTextModule
  ],
  exports: [
    LoginComponent
  ]
})
export class LoginModule { }
