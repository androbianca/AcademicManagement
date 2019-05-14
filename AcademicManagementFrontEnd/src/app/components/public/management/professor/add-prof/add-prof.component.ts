import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule } from '@angular/forms';
import { CourseService } from 'src/app/services/course-service.service';
import { CourseRead } from 'src/app/models/course-read';
import { GroupService } from 'src/app/services/group-service.service';
import { Professor } from 'src/app/models/professor';
import { ProfService } from 'src/app/services/prof-service.service';
import { PotentialUserService } from 'src/app/services/potentialuser-service.service';
import { ProfStudService } from 'src/app/services/prof-stud-service.service';
import { ProfStud } from 'src/app/models/prof-studs';
import { GroupRead } from 'src/app/models/groupRead';

@Component({
  selector: 'app-add-prof',
  templateUrl: './add-prof.component.html',
  styleUrls: ['./add-prof.component.scss']
})
export class AddProfComponent implements OnInit {

  profId: any;
  profStud = new ProfStud();
  courses: CourseRead[];
  groups: GroupRead[];
  allgroups: GroupRead[];
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

  constructor(private courseService: CourseService, 
    private groupService: GroupService, 
    private profService: ProfService, 
    private potentialUserService: PotentialUserService, 
    private profStudService: ProfStudService) { }

  ngOnInit() {
    this.getCourses();
    this.getGroups();
  }

  getCourses() {
    this.courseService.getAll().subscribe(result =>
      this.courses = result)
  }

  getGroups() {
    this.groupService.getAll().subscribe(result =>
      {console.log(result)
      this.groups = result}
    )
  }

  filterGroups(course){
    //this.groups = this.allgroups.filter(x=>x.year === course.year)
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

  addPotentialUser() {
    var usercode = this.addProfForm.get('userCode').value;
    this.potentialUserService.addPotentialUser(usercode).subscribe(response =>
        { 
          this.prof.potentialUserId =  response
          this.addProfessor();
        });
  }

  addProfessor(){
     this.profService.addProf(this.prof).subscribe((result: Professor) => {
       this.addProfStud(result.id)
     },
      error => {
      });}
  

  submit(form) {
    this.prof.firstName = form.value.firstName;
    this.prof.lastName = form.value.lastName;
    this.prof.userCode = form.value.userCode;
    this.addPotentialUser();
  }

  addProfStud(profId) {
    var profStuds = new Array<ProfStud>();
 
    this.forms.forEach(el => {
      var profStud = Object.assign({}, new ProfStud());
      profStud.courseId = this.addProfForm.get(el.course).value.id;
      profStud.groupId = this.addProfForm.get(el.group).value.id;
      profStud.profId = profId;
      profStuds.push(profStud);
    })

   this.profStudService.addProfStuds(profStuds).subscribe(response =>{})
  }

}
