import { Component, OnInit, ɵConsole, OnChanges } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Login } from "src/app/models/login";
import { Router } from "@angular/router";
import { AuthenticationService } from "src/app/services/authentication.service";
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent implements OnInit {

  public loginModel: Login = new Login();
  isDisabled =  true;
  loginForm = new FormGroup({
    userCode: new FormControl(null, [Validators.required]),
    password: new FormControl(null, [Validators.required])
  });

  constructor(
    private authenticationService: AuthenticationService, private currentUserService: CurrentUserDetailsService,
    private router: Router,
    private snackBar:MatSnackBar) { }

  ngOnInit() {  this.onChanges();
  }

onChanges(): void {
    this.loginForm.valueChanges.subscribe(x=> {
    this.isDisabled = this.loginForm.valid ? false :true;
    })
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  public login(form) {
    if (this.loginForm.valid) {
      this.isDisabled = false;
      localStorage.clear();
      this.currentUserService.isSet = false;
      this.loginModel.userCode = form.value.userCode;
      this.loginModel.password = form.value.password;
      this.authenticationService.authenticate(this.loginModel).subscribe(
        response => {
          let role = (<any>response).role;
          let token = (<any>response).token;
          localStorage.setItem("jwt", token);
          if (role == "Student") {
            this.router.navigate(["/studcourses"]);
          }
          if (role == "Admin") {
            this.router.navigate(["/manage/courses"]);
          }
          if (role == "Professor") {
            this.router.navigate(["/profcourses"]);
          }
          this.snackBar.open("succes");
        },
        err => { 
          this.snackBar.open("fail");

        }
      );
    }
  }
}
