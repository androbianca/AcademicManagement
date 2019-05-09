import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CourseService } from 'src/app/services/course-service.service';
import { GroupService } from 'src/app/services/group-service.service';
import { Group } from 'src/app/models/group';
import { CourseRead } from 'src/app/models/course-read';
import { PotentialUserService } from 'src/app/services/potentialuser-service.service';
import { Student } from 'src/app/models/student';
import { StudentService } from 'src/app/services/student-service.service';

@Component({
  selector: 'app-add-stud',
  templateUrl: './add-stud.component.html',
  styleUrls: ['./add-stud.component.scss']
})
export class AddStudComponent implements OnInit {

  courses: CourseRead[];
  groups: Group[];
  student = new Student();

  addStudForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    userCode: new FormControl(''),
    optionals: new FormControl(''),
    group: new FormControl(''),
  });

  constructor(private courseSrvice: CourseService, private groupService: GroupService, private potentialUserService: PotentialUserService, private studentService: StudentService) { }

  getOptionalCourses() {
    this.courseSrvice.getOptionalCourses().subscribe(response => {
      this.courses = response;
    })
  }

  getGroups() {
    this.groupService.getAll().subscribe(response => {
      this.groups = response;
    })
  }

  addPotentialUser() {
    var usercode = this.addStudForm.get('userCode').value;
    this.potentialUserService.addPotentialUser(usercode).subscribe(response => {
      this.student.potentialUserId = response
    });
  }

  addStudent() {
    this.studentService.addStudent(this.student).subscribe(response => { })
  }
  submit(form) {
    this.student.firstName = form.value.firstName;
    this.student.lastName = form.value.lastName;
    this.student.userCode = form.value.userCode;
    this.student.groupId = form.value.group.id;
    this.addPotentialUser();
  }

  ngOnInit() {
    this.getOptionalCourses();
    this.getGroups();
  }
}
