import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class UserService {
  private loggedIn: boolean = false;
  private userName: string = null;
  private roles: string[];
  private baseUrl: string;

  constructor(private http: Http) {
    this.baseUrl = 'http://suggestionboxaubg.azurewebsites.net';

    this.loggedIn = !!localStorage.getItem('access_token');
    this.userName = localStorage.getItem('user_name') || null;
    this.roles = localStorage.getItem('roles') ? localStorage.getItem('roles').split(',') : [];
  }

  login(username: string, password: string) {
    let headers = new Headers();
    headers.append('Content-Type', 'application/x-www-form-urlencoded');

    return this.http
      .post(`${this.baseUrl}/Token`,
        `grant_type=password&username=${username}&password=${password}`,
        { headers })
      .map(res => res.json())
      .map((res) => {
        localStorage.setItem('access_token', res.access_token);
        localStorage.setItem('user_name', res.userName);
        localStorage.setItem('roles', res.roles);

        this.loggedIn = true;
        this.userName = res.userName;
        this.roles = res.roles.split(',');

        return res;
      });
  }

  logout() {
    localStorage.removeItem('access_token');
    localStorage.removeItem('user_name');
    localStorage.removeItem('roles');

    this.loggedIn = false;
    this.userName = null;
    this.roles = [];
  }

  register(email: string, password: string, confirmPassword: string){
    return this.http
      .post(`${this.baseUrl}/api/Account/Register`,
        {"Email": email, "Password":password, "ConfirmPassword":confirmPassword});
  }

  isLoggedIn() {
    return this.loggedIn;
  }

  getUserName() {
    return this.userName;
  }

  isInRole(role: string) {
    return this.roles.indexOf(role) != -1;
  }
}
