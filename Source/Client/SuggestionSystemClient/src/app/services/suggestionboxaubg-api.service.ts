import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from '../../../node_modules/rxjs/Observable.d';
import 'rxjs/add/operator/map';
import { Headers } from '@angular/http'

@Injectable()
export class SuggestionboxaubgApiService {
  baseUrl: string;

  constructor(private http: Http) {
    this.baseUrl = 'http://suggestionboxaubg.azurewebsites.net/';
  }

  fetchSuggestions(page: number, itemsPerPage: number, orderBy: string, search: string, status: string, onlyMine: boolean, onlyUpVoted: boolean): Observable<any> {
    var url = this.baseUrl + '/api/Suggestions?';
    if (page) url += 'page=' + page;
    if (itemsPerPage) url += '&itemsPerPage=' + itemsPerPage;
    if (orderBy) url += '&orderBy=' + orderBy;
    if (search) url += '&search=' + search;
    if (status) url += '&status=' + status;
    if (onlyMine) url += '&onlyMine=true';
    if (onlyUpVoted) url += '&onlyUpVoted=true';

    return this.http.get(url, {headers: new Headers({"Authorization": "Bearer " + localStorage.getItem('access_token')})})
      .map(response => response.json());
  }

  fetchComments(id: number, from: number, count: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/Suggestions/${id}/comments?from=${from}&count=${count}`, {headers: new Headers({"Authorization": "Bearer " + localStorage.getItem('access_token')})})
      .map(response => response.json());
  }


  postComment(id: number, content: string) {
    return this.http.post(`${this.baseUrl}/api/Suggestions/${id}/comment`, {"Id": id, "Content": content}, {headers: new Headers({"Authorization": "Bearer " + localStorage.getItem('access_token')})})
      .map(response => response.json());
  }

  addSuggestion(title: string, content: string, isPrivate: boolean, isAnonymous: boolean) {
    return this.http.post(`${this.baseUrl}/api/Suggestions`, {"Title": title, "Content": content,
     "isPrivate": isPrivate, "isAnonymous": isAnonymous}, {headers: new Headers({"Authorization": "Bearer " + localStorage.getItem('access_token')})})
       .map(response => response.json());
  }

  vote(id: number, type: number) {
    return this.http.put(`${this.baseUrl}/api/Suggestions/${id}/vote`, {"Id": id, "Type": type}, {headers: new Headers({"Authorization": "Bearer " + localStorage.getItem('access_token')})})
      .map(response => response.json());
  }

  ChangeStatus(id: number, status: number) {
    return this.http.put(`${this.baseUrl}/api/Suggestions/${id}/changeStatus`, {"Status": status}, {headers: new Headers({"Authorization": "Bearer " + localStorage.getItem('access_token')})})
        .map(response => response.json());
  }

  deleteSuggestion(id: number) {
    return this.http.delete(`${this.baseUrl}/api/Suggestions/${id}`, {headers: new Headers({"Authorization": "Bearer " + localStorage.getItem('access_token')})})
        .map(response => response.json());
  }

  deleteComment(id: number) {
    return this.http.delete(`${this.baseUrl}/api/Comments/${id}`, {headers: new Headers({"Authorization": "Bearer " + localStorage.getItem('access_token')})})
      .map(response => response.json());
  }
}
