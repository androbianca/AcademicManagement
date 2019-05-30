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
  signupForm = new FormGroup({
    code: new FormControl('',[Validators.required]),
    password: new FormControl('',[Validators.required]),
    cpassword: new FormControl('',[Validators.required])
  });
  isDisabled= true;
  durationInSeconds = 5;

  constructor(private autenticationService: AuthenticationService,private snackBar: MatSnackBar) { }

  ngOnInit() { this.onChanges();
  }

  onChanges(): void {
    this.signupForm.valueChanges.subscribe(x=> {
    this.isDisabled = this.signupForm.valid ? false : true;
    })
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000,
    });
  }


  public register(form) {
    if(this.signupForm.valid ){
    this.user.userCode = form.value.code;
    this.user.email = form.value.email;
    this.user.password = form.value.password;
    this.autenticationService.register(this.user).subscribe(result => {
      this.openSnackBar("success","2");
    }, err => {

      this.openSnackBar("fail","2");

    });

  }}
}


