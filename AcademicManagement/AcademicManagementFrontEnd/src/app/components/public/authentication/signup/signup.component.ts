import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { User } from 'src/app/models/user';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  public user = new User();
  isDisabled = true;
  durationInSeconds = 5;
  errorMessage1 = "This field is required";
  errorMessage2 = "This field is required";


  signupForm = new FormGroup({
    code: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required,Validators.minLength(8)]),
    cpassword: new FormControl('', [Validators.required,Validators.minLength(8)])
  });

  constructor(private autenticationService: AuthenticationService, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.onChanges();
  }

  onChanges(): void {
    this.signupForm.valueChanges.subscribe(x => {
      var error1 =  this.signupForm.get('password').hasError('minlength');
      var error2 =  this.signupForm.get('cpassword').hasError('minlength');

      this.errorMessage1 = error1 ? "The password needs to have at least 8 characters" : "This field is required";
      this.errorMessage2 = error2 ? "The password needs to have at least 8 characters" : "This field is required";

      this.isDisabled = this.signupForm.valid ? false : true;
    })
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000,
    });
  }

  public register(form) {
    if (this.signupForm.valid) {
      this.user.userCode = form.value.code;
      this.user.email = form.value.email;
      this.user.password = form.value.password;
      this.autenticationService.register(this.user).subscribe(result => {
        this.openSnackBar("success", "2");
      }, err => {
        this.openSnackBar("fail", "2");

      });
    }
  }
}


