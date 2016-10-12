// app.routes.ts

import { Routes, RouterModule } from '@angular/router';

import { SuggestionsComponent } from './suggestions/suggestions.component';
import { NewSuggestionComponent } from './new-suggestion/new-suggestion.component';
import { ItemCommentsComponent } from './item-comments/item-comments.component';

const routes: Routes = [
  {path: '', redirectTo: 'news/1', pathMatch : 'full'},
  {path: 'news/:page', component: SuggestionsComponent, data: {storiesType: 'news'}},
  {path: 'newest/:page', component: SuggestionsComponent, data: {storiesType: 'newest'}},
  {path: 'show/:page', component: SuggestionsComponent, data: {storiesType: 'show'}},
  {path: 'ask/:page', component: SuggestionsComponent, data: {storiesType: 'ask'}},
  {path: 'jobs/:page', component: SuggestionsComponent, data: {storiesType: 'jobs'}},
  {path: 'item/:id', component: ItemCommentsComponent},
  {path: 'new_suggestion', component: NewSuggestionComponent}
];

export const routing = RouterModule.forRoot(routes);
