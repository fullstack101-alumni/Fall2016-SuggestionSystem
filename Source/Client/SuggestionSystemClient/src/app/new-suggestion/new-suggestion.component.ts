import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SuggestionboxaubgApiService } from '../suggestionboxaubg-api.service';

@Component({
  selector: 'app-new-suggestion',
  templateUrl: './new-suggestion.component.html',
  styleUrls: ['./new-suggestion.component.scss']
})
export class NewSuggestionComponent implements OnInit {

  constructor(private _suggestionBoxAubgApiService: SuggestionboxaubgApiService,
              private route: ActivatedRoute) { }

  ngOnInit() { 
  }

  onSubmit(form: any): void {
    console.log(form);
    this._suggestionBoxAubgApiService.addSuggestion(form.title, form.suggestion,
                                                    form.private, form.anonymous)
    .subscribe(
      data => alert(data),
      error => {}
    );
  }

}
