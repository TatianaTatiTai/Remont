import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-worker-home',
  templateUrl: './worker-home.component.html',
  styleUrls: ['./worker-home.component.css']
})
export class WorkerHomeComponent implements OnInit {
  public userName: string;
  public role: string;
  public email: string;


  constructor(
    private router: Router,
    private userService: UserService,
    public spinner: NgxSpinnerService,
  ) { }

  ngOnInit() {

    this.userName = localStorage.getItem('userName');
    this.role = localStorage.getItem('role');
    this.email = localStorage.getItem('email');
  }

  Logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
