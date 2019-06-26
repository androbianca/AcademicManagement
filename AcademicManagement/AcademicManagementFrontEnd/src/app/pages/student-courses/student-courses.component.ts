import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course-service.service';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { CourseRead } from 'src/app/models/course-read';

@Component({
  selector: 'app-courses',
  templateUrl: './student-courses.component.html',
  styleUrls: ['./student-courses.component.scss']
})

export class StudentCoursesComponent {

  courses: CourseRead[];
  user: UserDetails;
  route: string;
  cardMessage: string;

  constructor(private courseService: CourseService, private currentUserDetailservice: CurrentUserDetailsService) {
    this.user = currentUserDetailservice.getUser();
    this.cardMessage = 'See more';
    this.getAllCourses();
    this.route = 'studcourses/course/'
  }

  getAllCourses() {
    this.courseService.getAll().subscribe((response: CourseRead[]) => {
      this.courses = response.sort((n1, n2) => {
        if (n1.name > n2.name) {
          return 1;
        }
        else return -1;
      })
    });
  }
}
