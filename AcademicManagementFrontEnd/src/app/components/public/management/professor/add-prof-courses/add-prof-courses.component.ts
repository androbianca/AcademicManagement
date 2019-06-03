import { Component, OnInit } from '@angular/core';
import { Professor } from 'src/app/models/professor';
import { FormGroup, FormControl } from '@angular/forms';
import { ProfService } from 'src/app/services/prof-service.service';
import { CourseService } from 'src/app/services/course-service.service';
import { GroupService } from 'src/app/services/group-service.service';
import { CourseRead } from 'src/app/models/course-read';
import { GroupRead } from 'src/app/models/groupRead';
import { ProfStud } from 'src/app/models/prof-studs';
import { ProfStudService } from 'src/app/services/prof-stud-service.service';

@Component({
  selector: 'app-add-prof-courses',
  templateUrl: './add-prof-courses.component.html',
  styleUrls: ['./add-prof-courses.component.scss']
})
export class AddProfCoursesComponent implements OnInit {

  profs: Professor[];
  courses: CourseRead[];
  groups: GroupRead[];
  forms = [{ course: 'course1', group: 'group1' }];
  count = 1;

  addCourses = new FormGroup({
    prof: new FormControl(''),
    course1: new FormControl(''),
    group1: new FormControl('')
  });

  constructor(private profService: ProfService,
    private courseService: CourseService,
    private groupService: GroupService,
    private profStudService: ProfStudService) { }

  ngOnInit() {
    this.getProfs();
    this.getCourses();
    this.getGroups();
  }

  getProfs() {
    this.profService.getAll().subscribe(response => {
      this.profs = response;
    })
  }

  getCourses() {
    this.courseService.getAll().subscribe(result =>
      this.courses = result)
  }

  getGroups() {
    this.groupService.getAll().subscribe(result => {
      this.groups = result})
  }

  add() {
    var course = new FormControl('');
    var group = new FormControl('');
    this.count++;
    var cname = 'course' + this.count;
    var gname = 'group' + this.count;
    this.forms.push({ course: cname, group: gname })

    this.addCourses.addControl(cname, course);
    this.addCourses.addControl(gname, group);
  }

  submit(form) {
    var id = form.value.prof.id;
    this.addProfStud(id);
  }

  addProfStud(profId) {
    var profStuds = new Array<ProfStud>();
    this.forms.forEach(el => {
      var profStud = Object.assign({}, new ProfStud());
      profStud.courseId = this.addCourses.get(el.course).value.id;
      profStud.groupId = this.addCourses.get(el.group).value.id;
      profStud.profId = profId;
      profStuds.push(profStud);
    })
    this.profStudService.addProfStuds(profStuds).subscribe(response => { })
  }
}
