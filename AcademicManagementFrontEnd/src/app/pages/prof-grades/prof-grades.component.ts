import { Component, OnInit, HostBinding } from '@angular/core';
import { StudentService } from 'src/app/services/student-service.service';
import { ActivatedRoute } from '@angular/router';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { Student } from 'src/app/models/student';

@Component({
  selector: 'app-prof-grades',
  templateUrl: './prof-grades.component.html',
  styleUrls: ['./prof-grades.component.scss']
})
export class ProfGradesComponent implements OnInit {

  @HostBinding('class') classes = 'page-wrapper';

  courseId: string;
  user: UserDetails;
  students = new Array<Student>();
 
  constructor(private studentService: StudentService, private route: ActivatedRoute, private userDetailsService: CurrentUserDetailsService) {
    this.user = userDetailsService.getUser();
  }


  ngOnInit() {
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
    });
    this.studentService.getStudentsByProf(this.courseId).subscribe((result: Student[]) => {
      this.students = result;
    });
  }
}
