import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { SuggestionboxaubgApiService } from '../services/suggestionboxaubg-api.service.ts';
import { Suggestion } from "../models/suggestion";

@Component({
  selector: 'app-suggestions',
  templateUrl: './suggestions.component.html'
})

export class SuggestionsComponent implements OnInit {
  items: Suggestion[];
  pages: number[];
  currentPage: number;
  suggestionsPerPage: number;

  constructor(private _suggestionBoxAubgApiService:SuggestionboxaubgApiService,
              private route: ActivatedRoute,
              private router: Router) {
    this.suggestionsPerPage = 10;
    this.pages = [];
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.currentPage = params['page'];

      if (this.currentPage < 1) this.router.navigate(['/suggestions/1']);

      this._suggestionBoxAubgApiService.fetchSuggestions(this.currentPage)
        .subscribe(
          items => {
            this.items = items.Items;

            var temp = [];
            for (var i = 1; i < Math.ceil(items.ItemsCount / this.suggestionsPerPage) + 1; i++) {
              temp.push(i);
            }
            this.pages = temp;
          },
          error => console.log('Error fetching stories'))
    });
  }

  isFirstPage() {
    return this.currentPage == 1;
  }

  isLastPage() {
    return this.pages[this.pages.length - 1] == this.currentPage;
  }
}
