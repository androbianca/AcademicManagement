import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student-service.service';
import { ActivatedRoute } from '@angular/router';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';

@Component({
  selector: 'app-prof-grades',
  templateUrl: './prof-grades.component.html',
  styleUrls: ['./prof-grades.component.scss']
})
export class ProfGradesComponent implements OnInit {

  public courseId : string;
  public user: UserDetails;
  constructor(private studentService:StudentService,private route: ActivatedRoute, private userDetailsService:CurrentUserDetailsService) { 
    this.user = userDetailsService.getUser();
  }

  ngOnInit() {

    this.route.params.subscribe(params => {    
      this.courseId = params['courseId']; 
    });

    this.studentService.getStudentsByProf(this.courseId).subscribe(result=>{
      console.log(result);
    });
  }

}
