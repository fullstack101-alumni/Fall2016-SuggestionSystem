import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class SuggestionboxaubgApiService {
  baseUrl: string;

  constructor(private http: Http) {
    this.baseUrl = 'http://suggestionboxaubg.azurewebsites.net/api';
  }

  fetchItem(id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/Suggestions/${id}`)
      .map(response => response.json());
  }

  fetchSuggestions(page: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/Suggestions?page=${page}`)
      .map(response => response.json());
  }
}
