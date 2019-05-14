import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { GroupWrite } from 'src/app/models/groupWrite';
import { GroupService } from 'src/app/services/group-service.service';

@Component({
  selector: 'app-add-group',
  templateUrl: './add-group.component.html',
  styleUrls: ['./add-group.component.scss']
})
export class AddGroupComponent implements OnInit {

  addGroupForm = new FormGroup({
    name: new FormControl(''),
    year: new FormControl(''),
  });

  constructor(private groupService: GroupService) { }

  ngOnInit() {
  }

  submit(form) {

    var group = new GroupWrite();
    group.name = form.value.name;
    group.year = form.value.year;

    this.groupService.addGroup(group).subscribe(response => {});
  }

}
