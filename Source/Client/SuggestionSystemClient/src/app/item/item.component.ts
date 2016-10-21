import { Component, Input, OnInit } from '@angular/core';
import { SuggestionboxaubgApiService } from '../services/suggestionboxaubg-api.service.ts';
import { Suggestion } from "../models/suggestion";
import { Comment } from '../models/comment';

@Component({
  selector: 'item',
  templateUrl: './item.component.html'
})

export class ItemComponent implements OnInit {
  @Input() item: Suggestion;
  panelColor: string;
  comments: Comment[];
  numberOfCommentsToGet: number;
  commentContent: string;
  colors: string[];

  constructor(private _suggestionBoxAubgApiService:SuggestionboxaubgApiService) {}

  ngOnInit() {
    this.colors = ["warning", "primary", "default", "success", "danger"];
    this.panelColor = this.colors[this.item.Status];
    this.numberOfCommentsToGet = 5;
    this.comments = [];
  }

  getComments() {
    this._suggestionBoxAubgApiService.fetchComments(this.item.Id, this.comments.length, this.numberOfCommentsToGet)
    .subscribe(
      items => {for(var i=0; i < items.length; i++) this.comments.push(items[i])},
      error => console.log("Error fetching comments")
    );
  }

  postComment() {
    this._suggestionBoxAubgApiService.postComment(this.item.Id, this.commentContent)
    .subscribe(
      item => {
        this.comments.push(item);
        this.item.CommentsCount += 1;
        this.commentContent = "";
      },
      error => console.log(error)
    )
  }

  vote(voteType){
    this._suggestionBoxAubgApiService.vote(this.item.Id, voteType)
      .subscribe(
        items => {
          this.item.UpVotesCount = items.UpVotesCount;
          this.item.DownVotesCount = items.DownVotesCount;
        },
        error => console.log("Error voting for a suggestion")
      )
  }

  ChangeStatus(status) {
    this._suggestionBoxAubgApiService.ChangeStatus(this.item.Id, status)
        .subscribe(
            items => {
              this.item.Status = items.Status;
              this.panelColor = this.colors[this.item.Status];
            },
            error => console.log("Error changing status for a suggestion")
        )
  }
}
