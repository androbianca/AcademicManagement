import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

 public user = new User();
  signupForm = new FormGroup({
    code: new FormControl(''),
    email: new FormControl(''),
    fname: new FormControl(''),
    lname: new FormControl(''),
    password: new FormControl(''),
    cpassword: new FormControl('')
  });

  constructor(private autenticationService: AuthenticationService) { }

  ngOnInit() {
  }

  public register(form){
    this.user.UserCode = form.value.code;
    this.user.Email = form.value.email;
    this.user.LastName =form.value.lname;
    this.user.FirstName = form.value.fname;
    this.user.Password = form.value.password;

    this.autenticationService.register(this.user).subscribe(result => {
    }, err => {
    });
      
    }
  }


