// app.routes.ts

import { Routes, RouterModule } from '@angular/router';

import { SuggestionsComponent } from './suggestions/suggestions.component';
import { NewSuggestionComponent } from './new-suggestion/new-suggestion.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { LogInComponent } from './log-in/log-in.component';

const routes: Routes = [
  {path: '', redirectTo: 'suggestions/1', pathMatch : 'full'},
  {path: 'suggestions/:page', component: SuggestionsComponent},
  {path: 'new_suggestion', component: NewSuggestionComponent},
  {path: 'login', component: LogInComponent},
  {path: 'signup', component: SignUpComponent}
];

export const routing = RouterModule.forRoot(routes);
