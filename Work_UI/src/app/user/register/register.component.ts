import { Component, OnInit } from '@angular/core';
import { UserService, Config } from '../../shared/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RecaptchaFormsModule } from 'ng-recaptcha/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { CaptchaValidate } from '../models/captcha-validate.model';
import { User, UserReg } from '../../shared/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userReg: UserReg = new UserReg('', '', '', '', '', '', '', '','');

  constructor(
    private userService: UserService,
    private router: Router,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {

  }


  OnSubmit(userName: string, password: string, email: string) {
    this.spinner.show();
    this.userReg.UserName = userName;
    this.userReg.Email = email;
    this.userReg.Password = password;

    this.userService.userRegistration(this.userReg).subscribe((data: any) => {

      if (data == 0) {
        this.router.navigate(['/registration']);
        alert('Ошибка регистрации пользователя');
      }
      else {
        this.router.navigate(['/login']);
      }

    })
  }

  SignIn() {
    this.router.navigate(['/login']);
  }
}
