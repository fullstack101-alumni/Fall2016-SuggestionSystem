import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';

@Injectable()
export class UserService {
  private loggedIn = false;
  private baseUrl;

  constructor(private http: Http) {
    this.loggedIn = !!localStorage.getItem('auth_token');
    this.baseUrl = 'http://suggestionboxaubg.azurewebsites.net';
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
        console.log("asd");
        localStorage.setItem('auth_token', res.access_token);
        this.loggedIn = true;

        return res;
      });
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.loggedIn = false;
  }

  isLoggedIn() {
    return this.loggedIn;
  }
}
