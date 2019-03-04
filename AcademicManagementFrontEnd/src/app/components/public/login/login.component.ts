import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Login } from 'src/app/models/login';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginModel:Login = new Login();

  loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private authenticationService: AuthenticationService,private router: Router) { }

  ngOnInit() {
  }

  public login(form)
   {
    this.loginModel.Code = form.value.username;
    this.loginModel.Password = form.value.password;
    this.authenticationService.authenticate(this.loginModel).subscribe(response => {
      let token = (<any>response).token;
      localStorage.setItem("jwt", token);
      this.router.navigate(["/profile"]);
    }, err => {
    });
  }

}
