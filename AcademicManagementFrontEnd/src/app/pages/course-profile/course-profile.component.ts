import { Component, OnInit } from '@angular/core';
import { ProfService } from 'src/app/services/prof-service.service';
import { ActivatedRoute } from '@angular/router';
import { Professor } from 'src/app/models/professor';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { User } from 'src/app/models/user';
import { MatDialog } from '@angular/material/dialog';
import { GradeCategoryModalComponentComponent } from 'src/app/components/public/grade-category-modal-component/grade-category-modal-component.component';
import { FinalGradeService } from 'src/app/services/final-grade.service';
import { FinalGrade } from 'src/app/models/final-grade';

@Component({
  selector: 'app-course-profile',
  templateUrl: './course-profile.component.html',
  styleUrls: ['./course-profile.component.scss']
})
export class CourseProfileComponent implements OnInit {

  data : FinalGrade[];
  profs:Professor[];
  courseId:string;
  user:UserDetails;

  constructor(public dialog: MatDialog,
    private profService:ProfService, 
    private route:ActivatedRoute, 
    private currentUserService:CurrentUserDetailsService) {
    this.user = this.currentUserService.getUser();
   }

  ngOnInit() {
    this.getProfs();
  }


  getProfs(){
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
    });

    this.profService.getByCourseId(this.courseId).subscribe(response => {
      this.profs = response})
  }

}

