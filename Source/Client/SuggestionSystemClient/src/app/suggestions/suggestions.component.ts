import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { ActivatedRoute } from '@angular/router';
import { SuggestionboxaubgApiService } from '../suggestionboxaubg-api.service';

@Component({
  selector: 'app-suggestions',
  templateUrl: './suggestions.component.html',
  styleUrls: ['./suggestions.component.scss']
})
export class SuggestionsComponent implements OnInit {
  items;

  constructor(private _suggestionBoxAubgApiService:SuggestionboxaubgApiService) {}

  ngOnInit() {
    this._suggestionBoxAubgApiService.fetchSuggestions(1)
      .subscribe(
        items => this.items = items,
        error => console.log('Error fetching stories'));
  }
}
