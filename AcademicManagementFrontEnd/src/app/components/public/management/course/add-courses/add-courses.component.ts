import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CourseWrite } from 'src/app/models/course-write';
import { CourseService } from 'src/app/services/course-service.service';

@Component({
  selector: 'app-add-courses',
  templateUrl: './add-courses.component.html',
  styleUrls: ['./add-courses.component.scss']
})
export class AddCoursesComponent implements OnInit {

  course = new CourseWrite;
  addCourseForm = new FormGroup({
    name: new FormControl(''),
    year: new FormControl(''),
    semester: new FormControl(''),
    package: new FormControl('')
  });

  constructor(private courseService: CourseService) { }

  ngOnInit() {
  }

  addCourse() {
    this.courseService.addCourse(this.course).subscribe(result => { })
  }

  submit(form) {
    this.course.name = form.value.name;
    this.course.package = form.value.package;
    this.course.semester = form.value.semester;
    this.course.year = form.value.year;
    this.addCourse();
  }
}
