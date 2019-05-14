import { Component, OnInit } from '@angular/core';
import { GroupService } from 'src/app/services/group-service.service';
import { GroupRead } from 'src/app/models/groupRead';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-remove-group',
  templateUrl: './remove-group.component.html',
  styleUrls: ['./remove-group.component.scss']
})
export class RemoveGroupComponent implements OnInit {

  groups: GroupRead[];

  removeGroupForm = new FormGroup({
    group: new FormControl(''),
  });

  constructor(private groupService: GroupService) { }

  ngOnInit() {
    this.getGroups();
  }

  getGroups() {
    this.groupService.getAll().subscribe(result => { this.groups = result }
    )
  }

  removeGroup(id) {
    this.groupService.removeGroup(id).subscribe(response => { })
  }

  submit(form) {
    var id = form.value.group.id;
    this.removeGroup(id);
  }
}
