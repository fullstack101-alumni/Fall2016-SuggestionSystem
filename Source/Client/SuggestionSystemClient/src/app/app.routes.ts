// app.routes.ts

import { Routes, RouterModule } from '@angular/router';

import { SuggestionsComponent } from './suggestions/suggestions.component';
import { NewSuggestionComponent } from './new-suggestion/new-suggestion.component';
import { ItemCommentsComponent } from './item-comments/item-comments.component';
import { HotSuggestionsComponent } from './hot-suggestions/hot-suggestions.component'

const routes: Routes = [
  {path: '', redirectTo: 'suggestions/1', pathMatch : 'full'},
  {path: 'suggestions/:page', component: SuggestionsComponent},
  {path: 'hot_suggestions/:page', component: HotSuggestionsComponent},
  {path: 'item/:id', component: ItemCommentsComponent},
  {path: 'new_suggestion', component: NewSuggestionComponent}
];

export const routing = RouterModule.forRoot(routes);
