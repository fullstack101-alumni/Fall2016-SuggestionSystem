import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
  orderBy: string;
  search: string;
  status: string;
  onlyMine: boolean;
  onlyUpVoted: boolean;

  constructor(private _suggestionBoxAubgApiService:SuggestionboxaubgApiService,
              private route: ActivatedRoute,
              private router: Router) {
    this.suggestionsPerPage = 10;
    this.pages = [];
    this.orderBy = "DateCreated";
    this.search = null;
    this.status = "";
    this.onlyMine = false;
    this.onlyUpVoted = false;
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.currentPage = params['page'];
    });

    if (this.currentPage < 1) {
      this.router.navigate(['/suggestions/1']);
    }

    this.refreshContent();
  }

  isFirstPage() {
    return this.currentPage == 1;
  }

  isLastPage() {
    return this.pages[this.pages.length - 1] == this.currentPage;
  }

  getNextPage() {
    return Number(this.currentPage) + 1;
  }

  getPreviousPage() {
    return Number(this.currentPage) - 1;
  }

  refreshContent(fromFirstPage: boolean = false) {
    if (fromFirstPage) {
      this.currentPage = 1;
    }

    this._suggestionBoxAubgApiService.fetchSuggestions(this.currentPage, this.suggestionsPerPage, this.orderBy, this.search, this.status, this.onlyMine, this.onlyUpVoted)
      .subscribe(
        items => {
          this.items = items.Items;

          var pagesCount = Math.ceil(items.ItemsCount / this.suggestionsPerPage) + 1
          var temp = [];
          for (var i = 1; i < pagesCount; i++) {
            temp.push(i);
          }
          this.pages = temp;
        },
        error => console.log('Error fetching stories'))
  }
}
