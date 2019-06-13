import { Component, OnInit, Input, Output, HostBinding } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { OptionalService } from 'src/app/services/optional.service';
import { Opt } from 'src/app/models/optional';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-optionals',
  templateUrl: './optionals.component.html',
  styleUrls: ['./optionals.component.scss']
})
export class OptionalsComponent  {

  @HostBinding('class') classes = 'wrapper';

  fileToUpload: File = null;
  optional = new Opt();

  optionals = new FormGroup({
    year: new FormControl('', Validators.required),
    form: new FormControl('', Validators.required),
  });

  constructor(private optionalService:OptionalService,
    private router:Router,
    private snackBar: MatSnackBar) {
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  onFileChanged(event) {
    var files = event.target.files;
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    this.optional.file = fileToUpload;  
}

submit(){
  this.optional.googleForm = this.optionals.value.form;
  this.optional.year = this.optionals.value.year;
  this.optionalService.postFile(this.optional)
  .subscribe(result => {
    this.snackBar.open('success')
  },
  err => {
    this.snackBar.open('fail')
  });
}

goTo(){
  this.router.navigate(["/optionals"]);

}
}
