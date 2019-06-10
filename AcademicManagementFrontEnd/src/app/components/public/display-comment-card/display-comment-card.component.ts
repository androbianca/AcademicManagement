import { Component, OnInit, Input } from '@angular/core';
import { Comm } from 'src/app/models/comment';
import { Post } from 'src/app/models/post';
import { StudentService } from 'src/app/services/student-service.service';
import { ProfService } from 'src/app/services/prof-service.service';
import * as moment from 'moment'
import { Role } from 'src/app/models/role-enum';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { SignalRService } from 'src/app/services/signalR-service.service';
let myMoment: moment.Moment = moment("someDate");

@Component({
  selector: 'app-display-comment-card',
  templateUrl: './display-comment-card.component.html',
  styleUrls: ['./display-comment-card.component.scss']
})
export class DisplayCommentCardComponent implements OnInit {

  @Input() comment: Comm;
  @Input() post: Post;

  date: any;
  fullName: string;
  initials: string;
  role: typeof Role = Role;
  currentUser: UserDetails;
  user: any;


  constructor(private studentService: StudentService,
    private profService: ProfService,
    private signalRService: SignalRService,
    private currentUserDetailsService: CurrentUserDetailsService) {
    this.currentUser = this.currentUserDetailsService.getUser();
  }

  ngOnInit(): void {
    this.post.role == this.role.student ? this.getStudentDetails() : (this.currentUser.userRole == this.role.professor ? this.getProfDetails() : null)

    this.date = moment(this.post.time, "YYYYMMDD hh:mm").fromNow();
  }

  getStudentDetails() {
    this.studentService.getById(this.post.userCode).subscribe(x => {
      this.user = x;
      this.fullName = this.user.lastName + ' ' + this.user.firstName;
      this.initials = this.user.lastName[0] + ' ' + this.user.firstName[0];

    });
  }

  getProfDetails() {
    this.profService.getById(this.post.userCode).subscribe(x => {
      this.user = x;
      this.fullName = this.user.lastName + ' ' + this.user.firstName;
      this.initials = this.user.lastName[0] + ' ' + this.user.firstName[0];

    });
  }
}
