import { Component, Input, OnInit } from '@angular/core';
import { SuggestionboxaubgApiService } from '../suggestionboxaubg-api.service';

@Component({
  selector: 'item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit {
  @Input() item;
  panelColor: string;
  comments;
  numberOfCommentsToGet: number;

  constructor(private _suggestionBoxAubgApiService:SuggestionboxaubgApiService) {}

  ngOnInit() {
    var colors: string[] = ["warning", "primary", "default", "success", "danger"];
    this.panelColor = colors[this.item.Status];
    this.numberOfCommentsToGet = 1;
    this.comments = [];
  }

  getComments() {
    this._suggestionBoxAubgApiService.fetchComments(this.item.Id, this.comments.length, this.numberOfCommentsToGet)
    .subscribe(
      items => {for(var i=0; i < items.length; i++) this.comments.push(items[i])},
      error => console.log("Error fetching comments")
    );
  }
}
