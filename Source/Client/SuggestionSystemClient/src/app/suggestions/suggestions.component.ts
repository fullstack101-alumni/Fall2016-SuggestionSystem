import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SuggestionboxaubgApiService } from '../suggestionboxaubg-api.service';

@Component({
  selector: 'app-suggestions',
  templateUrl: './suggestions.component.html',
  styleUrls: ['./suggestions.component.scss']
})

export class SuggestionsComponent implements OnInit {
  pageSub: any;
  items;

  constructor(private _suggestionBoxAubgApiService:SuggestionboxaubgApiService,
              private route: ActivatedRoute) {}

  ngOnInit() {
    this.pageSub = this.route.params.subscribe(params => {
    this._suggestionBoxAubgApiService.fetchSuggestions(params['page'])
      .subscribe(
        items => this.items = items.Items,
        error => console.log('Error fetching stories'))
    });
  }
}
