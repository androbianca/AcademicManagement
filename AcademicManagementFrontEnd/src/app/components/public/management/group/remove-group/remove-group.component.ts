import { Component, OnInit } from '@angular/core';
import { GroupService } from 'src/app/services/group-service.service';
import { GroupRead } from 'src/app/models/groupRead';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-remove-group',
  templateUrl: './remove-group.component.html',
  styleUrls: ['./remove-group.component.scss']
})
export class RemoveGroupComponent implements OnInit {

  groups: GroupRead[];
  isDisabled = true;

  removeGroupForm = new FormGroup({
    group: new FormControl('', Validators.required),
  });


  constructor(private groupService: GroupService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.onChanges();
    this.getGroups();
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  onChanges() {
    this.removeGroupForm.valueChanges.subscribe(() => {
      if (this.removeGroupForm.valid) {
        this.isDisabled = false;
      }
    })
  }

  getGroups() {
    this.groupService.getAll().subscribe(result => { this.groups = result.filter(x => x.isDeleted == false) }
    )
  }

  removeGroup(id) {
    this.groupService.removeGroup(id).subscribe(response => {
      this.snackBar.open('success')
    }, err => {
      this.snackBar.open('fail')
    });
  }

  submit(form) {
    if(form.valid){
    var id = form.value.group.id;
    this.removeGroup(id);}
  }
}
