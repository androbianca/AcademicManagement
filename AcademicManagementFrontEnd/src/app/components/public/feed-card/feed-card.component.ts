import { Component, OnInit, Input } from '@angular/core';
import { Post } from 'src/app/models/post';
import { StudentService } from 'src/app/services/student-service.service';
import { ProfService } from 'src/app/services/prof-service.service';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { DatePipe } from '@angular/common';
import { Role } from 'src/app/models/role-enum';
import { UserDetails } from 'src/app/models/userDetails';
import * as moment from 'moment'
import { CommService } from 'src/app/services/comment.service';
import { Comm } from 'src/app/models/comment';
import { SignalRService } from 'src/app/services/signalR-service.service';
let myMoment: moment.Moment = moment("someDate");

@Component({
  selector: 'app-feed-card',
  templateUrl: './feed-card.component.html',
  styleUrls: ['./feed-card.component.scss']
})
export class FeedCardComponent implements OnInit {

  @Input() post: Post;
  
  currentUser: any;
  user:any;
  fullName: string;
  initials:string;
  comments :Comm[];
  date : any;
  role : typeof Role = Role;

  constructor(private studentService: StudentService,
    private profService: ProfService,
    private commService: CommService,
    private signalRService: SignalRService,
    private currentUserDetailsService: CurrentUserDetailsService) {
    this.currentUser = this.currentUserDetailsService.getUser();
  }

  ngOnInit() {
    this.registerOnServerEvents();
    this.getComments();
    this.post.role == this.role.student ? this.getStudentDetails() : (this.currentUser.userRole == this.role.professor ? this.getProfDetails() : null)
    this.fullName = this.currentUser.lastName + ' ' + this.currentUser.firstName;
    this.initials = this.currentUser.lastName[0] + ' ' + this.currentUser.firstName[0];
    this.date =  moment(this.post.time, "YYYYMMDD hh:mm").fromNow(); 

  }

  getStudentDetails() {
    this.studentService.getById(this.post.userCode).subscribe(x => this.user = x);
  }

  getProfDetails() {
    this.profService.getById(this.post.userCode).subscribe(x => this.user = x);
  }

  public registerOnServerEvents(): void {
    this.signalRService._hubConnection.on('message', () => {
      this.getComments();
    });
  }

  getComments(){
    this.commService.getByPostId(this.post.id).subscribe(x=>{
      this.comments = x;
    })
  }

}
