import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule } from '@angular/forms';
import { CourseService } from 'src/app/services/course-service.service';
import { CourseRead } from 'src/app/models/course-read';
import { GroupService } from 'src/app/services/group-service.service';
import { Group } from 'src/app/models/group';
import { Professor } from 'src/app/models/professor';
import { ProfService } from 'src/app/services/prof-service.service';
import { ProfStuds } from 'src/app/models/prof-studs';
import { runInThisContext } from 'vm';

@Component({
  selector: 'app-add-prof',
  templateUrl: './add-prof.component.html',
  styleUrls: ['./add-prof.component.scss']
})
export class AddProfComponent implements OnInit {

  profId: string;
  profStuds =  new Array<ProfStuds>();
  profStud = new ProfStuds();
  courses: CourseRead[];
  groups: Group[];
  prof = new Professor();
  count = 1;
  forms = [{ course: 'course1', group: 'group1' }];

  addProfForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    userCode: new FormControl(''),
    course1: new FormControl(''),
    group1: new FormControl('')
  });
 

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
    this.profService.addProf(this.prof);
    this.saveProfStud();
  }

  saveProfStud(){
    this.profStuds = new Array<ProfStuds>();
    var profStud = Object.assign({}, new ProfStuds);
    this.forms.forEach(el => {
      this.profStud.courseId = this.addProfForm.get(el.course).value.id;
      this.profStud.groupId = this.addProfForm.get(el.group).value.id;
      this.profStuds.push(this.profStud);
    })

    console.log(this.profStuds);
  }

}
