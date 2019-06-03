import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course-service.service';
import { CourseRead } from 'src/app/models/course-read';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-remove-course',
  templateUrl: './remove-course.component.html',
  styleUrls: ['./remove-course.component.scss']
})
export class RemoveCourseComponent implements OnInit {

  courses: CourseRead[];

  removeCourseForm = new FormGroup({
    course: new FormControl(''),
  });

  constructor(private courseService: CourseService) { }

  getCourses() {
    this.courseService.getAll().subscribe(response => {
      this.courses = response;
    })
  }
  ngOnInit() {
    this.getCourses();
  }

  submit(form) {
    var course = form.value.course;
    this.courseService.removeCourse(course.id).subscribe(() => { });
  }
}
