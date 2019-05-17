import { Component, OnInit, HostBinding } from '@angular/core';
import { GradeService } from 'src/app/services/grade-service.service';
import { ActivatedRoute } from '@angular/router';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { User } from 'src/app/models/user';
import { UserDetails } from 'src/app/models/userDetails';
import { Grade } from 'src/app/models/grade';

@Component({
  selector: 'app-course-grades',
  templateUrl: './course-grades.component.html',
  styleUrls: ['./course-grades.component.scss']
})
export class CourseGradesComponent implements OnInit {

  courseId : string;
  user:UserDetails;
  grades:Grade[];
  constructor(private gradesService:GradeService, private route:ActivatedRoute, private currentUser:CurrentUserDetailsService) { 
    this.user= currentUser.getUser();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
    });
    this.gradesService.getGrades2(this.courseId,this.user.id).subscribe(result=>
      this.grades = result
      );
  }

}
