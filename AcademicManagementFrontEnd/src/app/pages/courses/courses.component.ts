import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/course';
import { CourseService } from 'src/app/services/course-service.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent {
  courses: Course[];
  constructor(private courseService: CourseService) {
    this.getCourses();
  }

  getCourses() {
    this.courseService.getAll().subscribe((response: Course[]) => {
      this.courses = response.sort((n1, n2) => {
        if (n1.name > n2.name) {
          return 1;
        }
        else return -1;
      })
    });
  }
}
