import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CourseService } from 'src/app/services/course-service.service';
import { GroupService } from 'src/app/services/group-service.service';
import { CourseRead } from 'src/app/models/course-read';
import { PotentialUserService } from 'src/app/services/potentialuser-service.service';
import { Student } from 'src/app/models/student';
import { StudentService } from 'src/app/services/student-service.service';
import { StudCourse } from 'src/app/models/stud-course';
import { StudCourseService } from 'src/app/services/stud-course-service.service';
import { GroupRead } from 'src/app/models/groupRead';


@Component({
  selector: 'app-add-stud',
  templateUrl: './add-stud.component.html',
  styleUrls: ['./add-stud.component.scss']
})
export class AddStudComponent implements OnInit {

  courses: CourseRead[];
  groups: GroupRead[];
  optionals: any;
  student = new Student();
  studId: string;

  addStudForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    userCode: new FormControl(''),
    optionals: new FormControl(''),
    group: new FormControl(''),
  });

  constructor(private courseSrvice: CourseService,
    private groupService: GroupService,
    private potentialUserService: PotentialUserService,
    private studentService: StudentService,
    private StudCourseService: StudCourseService) { }

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
      this.addStudent();
    });
  }

  addStudent() {
    this.studentService.addStudent(this.student).subscribe(response => {
      this.studId = response.id;
      this.addStudCourses();
    })
  }

  addStudCourses() {
    var studCourses = new Array<StudCourse>();
    this.optionals = this.addStudForm.get('optionals').value;
    this.optionals.forEach(element => {
      var studCourse = Object.assign({}, new StudCourse());
      studCourse.courseId = element.id;
      studCourse.studId = this.studId;
      studCourses.push( studCourse);
    });
    this.StudCourseService.addStudCourses(studCourses).subscribe(response => {})
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
