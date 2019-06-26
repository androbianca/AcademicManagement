import { Component, OnInit } from '@angular/core';
import { Professor } from 'src/app/models/professor';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ProfService } from 'src/app/services/prof-service.service';
import { CourseService } from 'src/app/services/course-service.service';
import { GroupService } from 'src/app/services/group-service.service';
import { CourseRead } from 'src/app/models/course-read';
import { GroupRead } from 'src/app/models/groupRead';
import { ProfStud } from 'src/app/models/prof-studs';
import { ProfStudService } from 'src/app/services/prof-stud-service.service';
import { MatSnackBar } from '@angular/material/snack-bar';

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
  isDisabled = true;

  addCourses = new FormGroup({
    prof: new FormControl('',Validators.required),
    course1: new FormControl('',Validators.required),
    group1: new FormControl('',Validators.required)
  });
  allgroups: GroupRead[];

  constructor(private profService: ProfService,
    private courseService: CourseService,
    private groupService: GroupService,
    private snackBar: MatSnackBar,
    private profStudService: ProfStudService) { }

  ngOnInit() {
    this.getProfs();
    this.getCourses();
    this.getGroups();
    this.onChanges();
  }

  
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  onChanges() {
    this.addCourses.valueChanges.subscribe(() => {
      if (this.addCourses.valid) {
        this.isDisabled = false;
      }
    })
  }


  getProfs() {
    this.profService.getAll().subscribe(response => {
      this.profs = response.filter(x=> x.isDeleted == false);
    })
  }

  getCourses() {
    this.courseService.getAll().subscribe(result =>
      this.courses = result.filter(x=> x.isDeleted == false))
  }

  getGroups() {
    this.groupService.getAll().subscribe(result => {
      this.groups = result;
      this.allgroups = this.groups
    })
  }

  filterGroups(course) {
    this.groups = this.allgroups.filter(x=>x.year === course.year)
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
    if(form.valid){
    var id = form.value.prof.id;
    this.addProfStud(id);}
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
    this.profStudService.addProfStuds(profStuds).subscribe(response => {
      this.snackBar.open('success')
    }, err => {
      this.snackBar.open('fail')
    });
  }
}
