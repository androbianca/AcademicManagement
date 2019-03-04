import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Register } from 'src/app/models/register';
import { registerContentQuery } from '@angular/core/src/render3';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  registration = new Register();
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
    this.registration.Code = form.value.code;
    this.registration.Email = form.value.email;
    this.registration.LastName =form.value.lname;
    this.registration.FirstName = form.value.fname;
    this.registration.Password = form.value.password;

    this.autenticationService.register(this.registration).subscribe(result => {
       console.log(result)
    }, err => {
    });
      
    }
  }


