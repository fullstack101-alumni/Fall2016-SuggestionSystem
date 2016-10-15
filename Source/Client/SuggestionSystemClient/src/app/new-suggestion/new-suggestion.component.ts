import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SuggestionboxaubgApiService } from '../suggestionboxaubg-api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-suggestion',
  templateUrl: './new-suggestion.component.html',
  styleUrls: ['./new-suggestion.component.scss']
})

export class NewSuggestionComponent implements OnInit {

  constructor(private _suggestionBoxAubgApiService: SuggestionboxaubgApiService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit(form: any): void {
    this._suggestionBoxAubgApiService.addSuggestion(form.title, form.suggestion, form.private, form.anonymous)
    .subscribe(
      data => this.router.navigateByUrl("/suggestions/1"),
      error => console.log("Failed to make suggestion")
    );
  }

}
