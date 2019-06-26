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
import { PotentialUserService } from 'src/app/services/potentialuser-service.service';
import { UserRoleService } from 'src/app/services/user-role.service';
import { UserRole } from 'src/app/models/user-role';
import { CommentHub } from 'src/app/services/SignalR/comments-hub.service';
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
  fullName: string = " ";
  initials:string;
  comments :Comm[];
  date : any;
  role : string;
  

  constructor(private studentService: StudentService,
    private profService: ProfService,
    private potentialUserService: PotentialUserService,
    private userRoleService: UserRoleService,
    private commentHub: CommentHub,
    private commService: CommService,
    private currentUserDetailsService: CurrentUserDetailsService) {
    this.currentUser = this.currentUserDetailsService.getUser();
  }

  ngOnInit(): void {
    this.getUser();
    this.registerOnServerEvents();
    this.getComments();
    this.date = moment(this.post.time, "YYYYMMDD hh:mm").fromNow();
  }

  getUser() {
    this.potentialUserService.getByUserCode(this.post.userCode).subscribe(x => {
      this.fullName = x.lastName + ' ' + x.firstName;
      this.initials = x.lastName[0] + ' ' + x.firstName[0];
      this.getRole(x.roleId);
    });
  }

  getRole(id) {
    this.userRoleService.getById(id).subscribe(result => {
      this.role = result.name
    })
  }

  public registerOnServerEvents(): void {
    this.commentHub._hubConnection.on('comment', () => {
      this.getComments();
    });
  }

  getComments(){
    this.commService.getByPostId(this.post.id).subscribe(x=>{
      this.comments = x.sort((val1, val2) => {
        return new Date(val1.time).getTime() - new
          Date(val2.time).getTime()
      })
    })
  }

}
