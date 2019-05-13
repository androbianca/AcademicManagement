import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course-service.service';
import { CourseRead } from 'src/app/models/course-read';

@Component({
  selector: 'app-prof-courses',
  templateUrl: './prof-courses.component.html',
  styleUrls: ['./prof-courses.component.scss']
})
export class ProfCoursesComponent implements OnInit {

  courses: CourseRead[];
  route: string;
  cardMessage: string;

  ngOnInit() {
  }

 
  constructor(private courseService: CourseService) {
    this.cardMessage = 'See students';
    this.getProfCourses();
    this.route = 'courses/';
  }

  getProfCourses() {
    this.courseService.getProfCourses().subscribe((response: CourseRead[]) => {
      this.courses = response.sort((n1, n2) => {
        if (n1.name > n2.name) {
          return 1;
        }
        else return -1;
      })
    });
  }
}

