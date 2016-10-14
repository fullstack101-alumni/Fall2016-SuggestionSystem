import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SuggestionBoxaubgApiService } from '../suggestionboxaubg-api.service';

@Component({
  selector: 'app-new-suggestion',
  templateUrl: './new-suggestion.component.html',
  styleUrls: ['./new-suggestion.component.scss']
})
export class NewSuggestionComponent implements OnInit {

  constructor(private _suggestionBoxAubgApiService: SuggestionBoxaubgApiService
              private route: ActivatedRoute) { }

  ngOnInit() {
  }

}
