import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CourseService } from 'src/app/services/course-service.service';
import { CourseRead } from 'src/app/models/course-read';
import { GroupService } from 'src/app/services/group-service.service';
import { Group } from 'src/app/models/group';
import { Professor } from 'src/app/models/professor';
import { ProfService } from 'src/app/services/prof-service.service';

@Component({
  selector: 'app-add-prof',
  templateUrl: './add-prof.component.html',
  styleUrls: ['./add-prof.component.scss']
})
export class AddProfComponent implements OnInit {

  courses: CourseRead[];
  groups: Group[];
  prof = new Professor();
  count = 1;
  addProfForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    userCode: new FormControl(''),
    course1: new FormControl(''),
    group1: new FormControl('')
  });
  forms = [{ course: 'course1', group: 'group1' }];

  constructor(private courseService: CourseService, private groupService: GroupService, private profService: ProfService) { }

  getCourses() {
    this.courseService.getAll().subscribe(result =>
      this.courses = result)
  }

  getGroups() {
    this.groupService.getAll().subscribe(result =>
      this.groups = result
    )
  }
  ngOnInit() {
    this.getCourses();
    this.getGroups();
  }

  add() {

    var course = new FormControl('');
    var group = new FormControl('');
    this.count++;

    var cname = 'course' + this.count;
    var gname = 'group' + this.count;

    this.forms.push({ course: cname, group: gname })

    this.addProfForm.addControl(cname, course);
    this.addProfForm.addControl(gname, group);
  }

  submit(form) {
    this.prof.firstName = form.value.firstName;
    this.prof.lastName = form.value.lastName;
    this.prof.userCode = form.value.userCode;

    this.profService.addProf(this.prof).subscribe(result => console.log(result))
  }

}
