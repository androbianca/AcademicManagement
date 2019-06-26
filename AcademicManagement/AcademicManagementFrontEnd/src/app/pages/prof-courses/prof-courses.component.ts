import { Component, OnInit, ɵConsole } from '@angular/core';
import { CourseService } from 'src/app/services/course-service.service';
import { CourseRead } from 'src/app/models/course-read';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';

@Component({
  selector: 'app-prof-courses',
  templateUrl: './prof-courses.component.html',
  styleUrls: ['./prof-courses.component.scss']
})
export class ProfCoursesComponent {

  courses: CourseRead[];
  route: string;
  cardMessage: string;
  user: UserDetails;

  constructor(private courseService: CourseService, private currentUserDetailsService: CurrentUserDetailsService) {
    this.user = this.currentUserDetailsService.getUser();
    this.cardMessage = 'See students';
    this.getProfCourses();
    this.route = 'courses/';
  }

  getProfCourses() {
    this.courseService.getProfCourses(this.user.id).subscribe((response: CourseRead[]) => {
      this.courses = response.sort((n1, n2) => {
        if (n1.name > n2.name) {
          return 1;
        }
        else return -1;
      })
    });
  }
}

