import { Component, OnInit, HostBinding, ɵConsole } from '@angular/core';
import { GradeService } from 'src/app/services/grade-service.service';
import { ActivatedRoute } from '@angular/router';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
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
  grade= new Grade();
  finalGrade:number;
  hasPassed : boolean = false;

  constructor(private gradesService:GradeService, private route:ActivatedRoute, private currentUser:CurrentUserDetailsService) { 
    this.user= currentUser.getUser();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
    });
    this.gradesService.getGrades(this.courseId,this.user.id).subscribe(result=>
      {this.grades = result
      this.gradesService.getFinal(this.courseId,this.user.id).subscribe(x=> {
        this.finalGrade = x;
        this.grade.category ='Final grade';
        this.grade.value= this.finalGrade;
        this.hasPassed = this.finalGrade < 5 ? false : true;
      }
       )}
      );
  }

}
