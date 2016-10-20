import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'

@Component({
  selector: 'app-sign-out',
  templateUrl: './sign-out.component.html'
})
export class SignOutComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
    localStorage.removeItem('access_token');
    localStorage.removeItem('userName');
    localStorage.removeItem('roles');

    this.router.navigateByUrl("/suggestions/1");
  }

}
