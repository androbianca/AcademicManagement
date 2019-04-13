import { Component, OnInit, ɵConsole } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { Login } from "src/app/models/login";
import { Router } from "@angular/router";
import { AuthenticationService } from "src/app/services/authentication.service";
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent implements OnInit {
  public loginModel: Login = new Login();

  loginForm = new FormGroup({
    userCode: new FormControl(null),
    password: new FormControl(null)
  });

  constructor(
    private authenticationService: AuthenticationService,private currentUserService:CurrentUserDetailsService,
    private router: Router) {}

  ngOnInit() {}

  public login(form) {
    localStorage.clear();
    this.currentUserService.isSet = false;
    this.loginModel.userCode = form.value.userCode;
    this.loginModel.password = form.value.password;
    this.authenticationService.authenticate(this.loginModel).subscribe(
      response => {
        let token = (<any>response).token;
        localStorage.setItem("jwt", token);
        this.router.navigate(["/courses"]);
      },
      err => {}
    );
  }
}
