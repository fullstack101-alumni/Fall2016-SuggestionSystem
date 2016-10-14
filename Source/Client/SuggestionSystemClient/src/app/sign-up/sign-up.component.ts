import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SuggestionboxaubgApiService } from '../suggestionboxaubg-api.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {
  email: string
  password: string
  confirmPassword: string


  constructor(private _suggestionBoxAubgApiService:SuggestionboxaubgApiService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this._suggestionBoxAubgApiService.registerUser(this.email, this.password, this.confirmPassword)
      .subscribe(
        data => {
          this.route.navigate="/login";
          error => console.log('Error fetching stories'))
        }
      )
  }

}
