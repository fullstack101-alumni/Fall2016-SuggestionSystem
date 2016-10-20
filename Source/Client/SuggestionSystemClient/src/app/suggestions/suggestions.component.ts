import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SuggestionboxaubgApiService } from '../services/suggestionboxaubg-api.service.ts';
import { Suggestion } from "../models/suggestion";

@Component({
  selector: 'app-suggestions',
  templateUrl: './suggestions.component.html'
})

export class SuggestionsComponent implements OnInit {
  items: Suggestion[];
  itemsCount: number;

  constructor(private _suggestionBoxAubgApiService:SuggestionboxaubgApiService,
              private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this._suggestionBoxAubgApiService.fetchSuggestions(params['page'])
        .subscribe(
          items => {
            this.items = items.Items;
            this.itemsCount = items.Count;
          },
          error => console.log('Error fetching stories'))
    });
  }
}
