import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { UserService } from "../services/user.service.ts";

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html'
})
export class LogInComponent {

  constructor(private userService: UserService,
              private router: Router) { }

  onSubmit(form: any) {
    this.userService.login(form.email, form.password)
      .subscribe(
        data => this.router.navigate(['']),
        error => console.log(error)
      )
  }
}
