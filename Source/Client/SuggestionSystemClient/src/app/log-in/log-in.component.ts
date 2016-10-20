import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import { SuggestionboxaubgApiService } from '../services/suggestionboxaubg-api.service.ts';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html'
})
export class LogInComponent implements OnInit {
  errors;

  constructor(private _suggestionBoxAubgApiService:SuggestionboxaubgApiService,
              private router: Router) { }

  ngOnInit() {
  }

  onSubmit(form: any): void {
    this._suggestionBoxAubgApiService.logInUser(form.email, form.password)
      .subscribe(
        data => {
          localStorage.setItem('access_token', data.access_token);
          localStorage.setItem('roles', data.roles);
          localStorage.setItem('userName', data.userName);

          this.router.navigateByUrl("suggestions/1");
        },
        error => this.errors = JSON.parse(error._body).error_description
      )
  }
}
