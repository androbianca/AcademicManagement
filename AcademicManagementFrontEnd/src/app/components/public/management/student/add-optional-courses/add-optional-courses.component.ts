import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/models/student';
import { FormControl, FormGroup } from '@angular/forms';
import { StudentService } from 'src/app/services/student-service.service';
import { CourseService } from 'src/app/services/course-service.service';
import { CourseWrite } from 'src/app/models/course-write';
import { StudCourseService } from 'src/app/services/stud-course-service.service';
import { StudCourse } from 'src/app/models/stud-course';
import { CourseRead } from 'src/app/models/course-read';

@Component({
  selector: 'app-add-optional-courses',
  templateUrl: './add-optional-courses.component.html',
  styleUrls: ['./add-optional-courses.component.scss']
})
export class AddOptionalCoursesComponent implements OnInit {

  studs:Student[];
  courses:CourseRead[];
  
  addCoursesForm = new FormGroup({
    stud: new FormControl(''),
    optionals: new FormControl(''),
  });

  constructor(private studService:StudentService, private courseService:CourseService, private studCourseService:StudCourseService) { }

  ngOnInit() {
    this.getStudents();
    this.getOptionalCourses();
  }

  getStudents(){
  this.studService.getAll().subscribe(response => {
    this.studs = response;
  })
  }

  getOptionalCourses() {
    this.courseService.getOptionalCourses().subscribe(response => {
      this.courses = response;
    })
  }

  addStudCourses(id) {
    var studCourses = new Array<StudCourse>();
    this.courses = this.addCoursesForm.get('optionals').value;
    this.courses.forEach(element => {
      var studCourse = Object.assign({}, new StudCourse());
      studCourse.courseId = element.id;
      studCourse.studId = id;
      studCourses.push(studCourse);
    });
    this.studCourseService.addStudCourses(studCourses).subscribe(response => {})
  }

  submit(form){
    var id = form.value.stud.id;
    this.addStudCourses(id);
  }
}
