import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { routing } from './app.routes';
import { SuggestionboxaubgApiService } from './suggestionboxaubg-api.service';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { SuggestionsComponent } from './suggestions/suggestions.component';
import { FooterComponent } from './footer/footer.component';
import { ItemComponent } from './item/item.component';
import { NewSuggestionComponent } from './new-suggestion/new-suggestion.component';
import { ItemCommentsComponent } from './item-comments/item-comments.component';
import { HotSuggestionsComponent } from './hot-suggestions/hot-suggestions.component';
import { CommentTreeComponent } from './comment-tree/comment-tree.component';
import { CommentComponent } from './comment/comment.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SuggestionsComponent,
    FooterComponent,
    ItemComponent,
    NewSuggestionComponent,
    ItemCommentsComponent,
    HotSuggestionsComponent,
    CommentTreeComponent,
    CommentComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
  ],
  providers: [SuggestionboxaubgApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
