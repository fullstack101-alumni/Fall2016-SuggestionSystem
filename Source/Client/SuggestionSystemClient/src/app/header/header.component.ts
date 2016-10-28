import { Component, OnInit } from '@angular/core';
import { UserService } from "../services/user.service.ts";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {
  constructor(private userService: UserService) { }

  logOut() {
    this.userService.logout();
  }
}
