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
  pageNum: number;
  listStart: number;

  constructor(private _suggestionBoxAubgApiService:SuggestionboxaubgApiService,
              private route: ActivatedRoute) {}

  ngOnInit() {
    this.pageSub = this.route.params.subscribe(params => {
      this.pageNum = +params['page'] ? +params['page'] : 1;
    this._suggestionBoxAubgApiService.fetchSuggestions(this.pageNum)
      .subscribe(
        items => this.items = items,
        error => console.log('Error fetching stories'),
        () => this.listStart = ((this.pageNum - 1) * 20) + 1);
    });
  }
}
