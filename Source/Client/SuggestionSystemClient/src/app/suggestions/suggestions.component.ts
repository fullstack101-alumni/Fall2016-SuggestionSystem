import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-suggestions',
  templateUrl: './suggestions.component.html',
  styleUrls: ['./suggestions.component.scss']
})
export class SuggestionsComponent implements OnInit {
  items: number[];

  constructor() {
    this.items = Array(30).map((x,i)=>i);
  }

  ngOnInit() {
  }

}
