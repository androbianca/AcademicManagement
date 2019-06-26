import { Component, OnInit, HostBinding } from '@angular/core';
import { CourseRead } from 'src/app/models/course-read';
import { CourseService } from 'src/app/services/course-service.service';


@Component({
  selector: 'app-update-course',
  templateUrl: './update-course.component.html',
  styleUrls: ['./update-course.component.scss']
})
export class UpdateCourseComponent implements OnInit {

  @HostBinding('class') classes = 'wrapper';
  courses: CourseRead[];

  constructor(private courseService: CourseService) {
  }

  ngOnInit(): void {
    this.getCourses();
  }

  getCourses() {
    this.courseService.getAll().subscribe(response => {
      this.courses = response;
    })
  }

}
