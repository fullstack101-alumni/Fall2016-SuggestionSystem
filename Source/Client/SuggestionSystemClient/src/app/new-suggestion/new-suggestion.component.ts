import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SuggestionboxaubgApiService } from '../services/suggestionboxaubg-api.service.ts';
import { Router } from '@angular/router';
import { Utility } from '../utility';

@Component({
  selector: 'app-new-suggestion',
  templateUrl: './new-suggestion.component.html'
})

export class NewSuggestionComponent implements OnInit {
  constructor(private _suggestionBoxAubgApiService: SuggestionboxaubgApiService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit(form: any): void {
    form.private = form.private || false;
    let anonymous: boolean = !Utility.isUserLoggedIn();
    this._suggestionBoxAubgApiService.addSuggestion(form.title, form.suggestion, form.private, anonymous)
      .subscribe(
      data => this.router.navigateByUrl('/suggestions/1'),
      error => {
        console.log(error)
      }
      );
  }

}
