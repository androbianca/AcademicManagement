import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

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
