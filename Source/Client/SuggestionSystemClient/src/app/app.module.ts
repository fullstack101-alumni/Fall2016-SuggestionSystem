import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { routing } from './app.routes';
import { SuggestionboxaubgApiService } from './services/suggestionboxaubg-api.service.ts';
import { AppComponent } from './app/app.component.ts';
import { HeaderComponent } from './header/header.component';
import { SuggestionsComponent } from './suggestions/suggestions.component';
import { ItemComponent } from './item/item.component';
import { NewSuggestionComponent } from './new-suggestion/new-suggestion.component';
import { LogInComponent } from './log-in/log-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { CommentComponent } from './comment/comment.component';
import { UserService } from "./services/user.service.ts";


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SuggestionsComponent,
    ItemComponent,
    NewSuggestionComponent,
    LogInComponent,
    SignUpComponent,
    CommentComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
  ],
  providers: [
    SuggestionboxaubgApiService,
    UserService
  ],
  bootstrap: [
    AppComponent
  ]
})

export class AppModule { }
