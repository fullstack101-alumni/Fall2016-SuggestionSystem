import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { UserService } from "../services/user.service";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html'
})
export class SignUpComponent {

  constructor(private userService:UserService,
              private router: Router) { }

  onSubmit(form: any): void {
    this.userService.register(form.email, form.password, form.confirmPassword)
      .subscribe(
        data => this.router.navigate(['/login']),
        error => console.log(error)
      );
  }
}
