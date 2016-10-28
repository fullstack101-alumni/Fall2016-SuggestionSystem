import { Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { SuggestionboxaubgApiService } from '../services/suggestionboxaubg-api.service.ts';
import { Suggestion } from "../models/suggestion";
import { Comment } from '../models/comment';
import {UserService} from "../services/user.service";

@Component({
  selector: 'item',
  templateUrl: './item.component.html'
})

export class ItemComponent {
  @Input() item: Suggestion;
  @Input() statuses: string[];
  @Output() onChange = new EventEmitter();
  comments: Comment[] = [];
  numberOfCommentsToGet: number = 5;
  commentContent: string;
  colors: string[] = ["warning", "primary", "default", "success", "danger"];

  constructor(private _suggestionBoxAubgApiService:SuggestionboxaubgApiService,
              private userService: UserService) {}

  getComments() {
    this._suggestionBoxAubgApiService.fetchComments(this.item.Id, this.comments.length, this.numberOfCommentsToGet)
    .subscribe(
      items => {
        for(var i=0; i < items.length; i++)
          this.comments.push(items[i])
      },
      error => console.log("Error fetching comments!")
    );
  }

  hideComments() {
    this.comments = [];
  }

  postComment() {
    this._suggestionBoxAubgApiService.postComment(this.item.Id, this.commentContent)
    .subscribe(
      item => {
        this.comments.splice(0, 0, item);
        this.item.CommentsCount += 1;
        this.commentContent = "";
      },
      error => console.log("Error posting a comment!")
    )
  }

  vote(voteType){
    this._suggestionBoxAubgApiService.vote(this.item.Id, voteType)
      .subscribe(
        items => {
          this.item.UpVotesCount = items.UpVotesCount;
          this.item.DownVotesCount = items.DownVotesCount;
          this.onChange.emit();
        },
        error => console.log("Error voting for a suggestion")
      )
  }

  ChangeStatus(status) {
    this._suggestionBoxAubgApiService.ChangeStatus(this.item.Id, status)
        .subscribe(
            items => {
              this.onChange.emit();
              this.item.Status = items.Status;
            },
            error => console.log("Error changing status for a suggestion")
        )
  }

  delete() {
    this._suggestionBoxAubgApiService.deleteSuggestion(this.item.Id)
      .subscribe(
        items => {
          console.log(items);
          this.onChange.emit();
        },
        error => console.log(error))
  }
}
