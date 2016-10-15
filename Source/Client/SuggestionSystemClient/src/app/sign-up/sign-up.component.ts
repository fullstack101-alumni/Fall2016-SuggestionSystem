import { Component, OnInit } from '@angular/core';
import { SuggestionboxaubgApiService } from '../suggestionboxaubg-api.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
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
        data => alert(data),
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
