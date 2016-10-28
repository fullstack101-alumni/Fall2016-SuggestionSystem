import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class UserService {
  private loggedIn: boolean = false;
  private userName: string = null;
  private baseUrl;

  constructor(private http: Http) {
    this.baseUrl = 'http://suggestionboxaubg.azurewebsites.net';

    this.loggedIn = !!localStorage.getItem('access_token');
    this.userName = localStorage.getItem('user_name') || null;
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

        this.loggedIn = true;
        this.userName = res.userName;

        return res;
      });
  }

  logout() {
    localStorage.removeItem('access_token');
    localStorage.removeItem('user_name');

    this.loggedIn = false;
    this.userName = null;
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
}
