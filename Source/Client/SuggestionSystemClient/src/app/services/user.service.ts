import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';

@Injectable()
export class UserService {
  private loggedIn: boolean = false;
  private userName: string = null;
  private baseUrl;

  constructor(private http: Http) {
    this.baseUrl = 'http://suggestionboxaubg.azurewebsites.net';

    this.loggedIn = !!localStorage.getItem('auth_token');
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
        localStorage.setItem('auth_token', res.access_token);
        localStorage.setItem('user_name', res.userName);

        this.loggedIn = true;
        this.userName = res.userName;

        return res;
      });
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.loggedIn = false;
  }

  registerUser(email: string, password: string, confirmPassword: string){
    return this.http.post(`${this.baseUrl}/api/Account/Register`, {"Email": email, "Password":password, "ConfirmPassword":confirmPassword})
      .map(response => response.json());
  }

  isLoggedIn() {
    return this.loggedIn;
  }

  getUserName() {
    return this.userName;
  }
}
