import { Component, OnInit } from '@angular/core';
import { UserService, Config } from '../../shared/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RecaptchaFormsModule } from 'ng-recaptcha/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { CaptchaValidate } from '../models/captcha-validate.model';

@Component({
  selector: 'app-sing-in',
  templateUrl: './sing-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(
    private userService: UserService,
    private router: Router,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {

  }

  OnSubmit(userName: string, password: string) {
    this.spinner.show();
    this.userService.userAuthentication(userName, password).subscribe((data: any) => {
      if (data == 0) {
        alert('Неверные логин или пароль');
        this.spinner.hide();
      } else {
        localStorage.setItem('role', data.Role.RoleName);
        localStorage.setItem('userName', data.UserName);
        localStorage.setItem('email', data.Email);
        localStorage.setItem('userId', data.Id);

        if (data.Role.RoleName == "Пользователь") {
          this.router.navigate(['/home']);
        }

        if (data.Role.RoleName == "Администратор") {
          this.router.navigate(['/admin-home']);
        }

        if (data.Role.RoleName == "Сотрудник компании") {
          this.router.navigate(['/worker-home']);
        }

      }
    })
  }

  Register() {
    this.router.navigate(['/registration']);
  }
}
