import { Component, OnInit } from '@angular/core';
import { SuggestionboxaubgApiService } from '../services/suggestionboxaubg-api.service.ts';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html'
})
export class SignUpComponent implements OnInit {
  errors;
  usernameFlag;
  success;
  keys;

  constructor(private _suggestionBoxAubgApiService:SuggestionboxaubgApiService) { }

  ngOnInit() {
  }

  onSubmit(form: any): void {
    this._suggestionBoxAubgApiService.registerUser(form.email, form.password, form.confirmPassword)
      .subscribe(
        data => console.log(data),
        error => {
          try {
            try {
              this.errors = JSON.parse(error._body).ModelState;
              this.keys = Object.keys(this.errors);
              this.usernameFlag = true
            }
            catch (e) {
              this.errors = JSON.parse(error._body).Message;
              this.keys = Object.keys(this.errors);
              this.usernameFlag = false
            }
          }
          catch (e) {
            this.success = true
          }
        }
      )
  }

}
