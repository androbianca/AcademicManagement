import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/course';
import { CourseService } from 'src/app/services/course-service.service';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent {
  courses: Course[];
  user: UserDetails;
  route: string;
  cardMessage: string;
  constructor(private courseService: CourseService, private currentUserDetailservice: CurrentUserDetailsService) {
    this.user = currentUserDetailservice.getUser();
    this.cardMessage = this.user.isStudent ? 'See more' : 'Add grades';
    if (this.user.isStudent) {
      this.getAllCourses();
      this.route = 'courses/grades/'
      return;
    }
    this.getProfCourses();
    this.route = 'courses/';
  }

  getAllCourses() {
    this.courseService.getAll().subscribe((response: Course[]) => {
      this.courses = response.sort((n1, n2) => {
        if (n1.name > n2.name) {
          return 1;
        }
        else return -1;
      })
    });
  }

  getProfCourses() {
    this.courseService.getProfCourses().subscribe((response: Course[]) => {
      this.courses = response.sort((n1, n2) => {
        if (n1.name > n2.name) {
          return 1;
        }
        else return -1;
      })
    });
  }
}
