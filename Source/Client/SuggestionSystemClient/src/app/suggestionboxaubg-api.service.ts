import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class SuggestionboxaubgApiService {
  baseUrl: string;

  constructor(private http: Http) {
    this.baseUrl = 'http://suggestionboxaubg.azurewebsites.net';
  }

  fetchSuggestions(page: number = 1, itemsPerPage: number = 20, orderBy: string = "DateCreated", onlyMine: boolean = false, onlyUpVoted: boolean = false): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/Suggestions?page=${page}&itemsPerPage=${itemsPerPage}&orderBy=${orderBy}&onlyMine=${onlyMine}&onlyUpVoted=${onlyUpVoted}`)
      .map(response => response.json());
  }

  registerUser(email: string, password: string, confirmPassword: string){
    return this.http.post(`${this.baseUrl}/api/Account/Register`, {"Email": email, "Password":password, "ConfirmPassword":confirmPassword})
      .map(response => response.json());

  }

  fetchComments(id: number, from: number, count: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/Suggestions/${id}/comments?from=${from}&count=${count}`)
      .map(response => response.json());
  }


  postComment(id: number, content: string) {
    return this.http.post(`${this.baseUrl}/api/Suggestions/${id}/comment`, {"Id": id, "Content": content})
      .map(response => response.json());
  }

  addSuggestion(title: string, content: string, isPrivate: boolean, isAnnonymous: boolean) {
    return this.http.post(`${this.baseUrl}/api/Suggestions`, {"Title": title, "Content": content,
     "isPrivate": isPrivate, "isAnnonymous": isAnnonymous})
       .map(response => response.json());
  }

  vote(id: number, type: number) {
    return this.http.put(`${this.baseUrl}/api/Suggestions/${id}/vote`, {"Id": id, "Type": type})
      .map(response => response.json());
  }
}
