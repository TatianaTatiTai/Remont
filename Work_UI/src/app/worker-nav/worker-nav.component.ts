import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-worker-nav',
  templateUrl: './worker-nav.component.html',
  styleUrls: ['./worker-nav.component.css'],
})
export class WorkerNavComponent implements OnInit {
  public userName = '';
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(
    private breakpointObserver: BreakpointObserver,
    private router: Router,
    ) {
    }

    ngOnInit () {
    }

  Profile() {
    this.router.navigate(['/worker-home']);
  }

  Logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
