import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit {
  isLogged: boolean;
  userName: string;

  constructor() { }

  ngOnInit() {
    this.userName = localStorage.getItem('userName');
    this.isLogged = this.userName !== null;
  }
}
