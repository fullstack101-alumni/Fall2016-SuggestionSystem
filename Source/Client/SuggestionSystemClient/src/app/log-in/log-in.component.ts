import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import { SuggestionboxaubgApiService } from '../suggestionboxaubg-api.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
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
          this.router.navigateByUrl("/suggestions/1");
          console.log(data.access_token);
        },
        error => this.errors = JSON.parse(error._body).error_description
      )
  }
}
