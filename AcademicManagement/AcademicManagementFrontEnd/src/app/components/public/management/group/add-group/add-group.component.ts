import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { GroupWrite } from 'src/app/models/groupWrite';
import { GroupService } from 'src/app/services/group-service.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-group',
  templateUrl: './add-group.component.html',
  styleUrls: ['./add-group.component.scss']
})
export class AddGroupComponent implements OnInit {

  errorMessage = "This field is required!";
  isDisabled = true;
  addGroupForm = new FormGroup({
    name: new FormControl('', Validators.required),
    year: new FormControl('', Validators.required),
  });

  constructor(private groupService: GroupService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.onChanges();
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  onChanges() {
    this.addGroupForm.valueChanges.subscribe(() => {
      if (this.addGroupForm.valid) {
        this.isDisabled = false;
      }
    })
  }

  submit(form) {
    if (this.addGroupForm.valid) {
      var group = new GroupWrite();
      group.name = form.value.name;
      group.year = form.value.year;
      this.groupService.addGroup(group).subscribe(response => {
        this.snackBar.open('success')
      }, err => {
        this.snackBar.open('fail')
      });
    }
  }

}
