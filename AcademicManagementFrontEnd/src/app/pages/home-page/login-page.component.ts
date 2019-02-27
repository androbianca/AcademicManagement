import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  public isSignIn:boolean = true;
  
  constructor() { }

  ngOnInit() {
  }

  public changeToSignIn(){
    this.isSignIn = true;
  }
  public changeToSignUp(){
    this.isSignIn = false;
  }
}
