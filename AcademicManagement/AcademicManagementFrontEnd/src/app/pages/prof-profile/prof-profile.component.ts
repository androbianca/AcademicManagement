import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course-service.service';
import { ActivatedRoute } from '@angular/router';
import { CourseRead } from 'src/app/models/course-read';
import { MatDialog } from '@angular/material/dialog';
import { FeedbackService } from 'src/app/services/feedback-service.service';
import { StudentService } from 'src/app/services/student-service.service';
import { Feedback } from 'src/app/models/feedback';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { Role } from 'src/app/models/role-enum';
import { AddFeedbackModalContentComponent } from 'src/app/components/public/feedback/add-feedback-modal-content/add-feedback-modal-content.component';

export interface FeedbackStud {
  Body: string;
  UserName: string;
  Initials: string;
}

@Component({
  selector: 'app-prof-profile',
  templateUrl: './prof-profile.component.html',
  styleUrls: ['./prof-profile.component.scss']
})
export class ProfProfileComponent implements OnInit {

  profId: string;
  courses: CourseRead[];
  studId: string;
  feedbackStud = new Array<FeedbackStud>();
  route: string;
  user: UserDetails;
  role: typeof Role = Role;
  isStudent: boolean;
  feedbackList = new Array<Feedback>();
  
  constructor(private courseService: CourseService,
    private activeRoute: ActivatedRoute,
    public dialog: MatDialog,
    private feedbackService: FeedbackService,
    private currentUserService: CurrentUserDetailsService,
    private studentSevice: StudentService) {
    this.user = this.currentUserService.getUser();
    this.isStudent = this.user.userRole == this.role.student ? true : false;
    this.activeRoute.params.subscribe(params => {
      this.profId = params['profId'];
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddFeedbackModalContentComponent, {
      width: '400px',
      data: { reciverId: this.profId }
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  ngOnInit() {
    this.route = this.user.userRole == 'Professor' ? 'courses/' : 'studcourses/course/';
    this.getCourses();
    this.getFeedback();
  }

  getCourses() {
    this.courseService.getProfCourses(this.profId).subscribe(response => {
      this.courses = response;
    })
  }

  getFeedback() {
    this.feedbackService.getByProfId(this.profId).subscribe(response => {
      this.feedbackList = response;
      this.getStudent();
    })
  }

  getStudent() {
    this.feedbackList.forEach(item => {
      if (item.studentId) {
        this.studentSevice.getById(item.studentId).subscribe(x => {
          var name = x.lastName + ' ' + x.firstName;
          var initials = x.lastName[0] + ' ' + x.firstName[0];
          this.feedbackStud.push({ 'Body': item.body, 'UserName': name, 'Initials': initials })
        })
        return;
      }
      this.feedbackStud.push({ 'Body': item.body, 'UserName': 'Unknown', 'Initials': 'UNK' })
    })
  }
}
