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
import { PotentialUserService } from 'src/app/services/potentialuser-service.service';
import { UserRole } from 'src/app/models/user-role';
import { UserRoleService } from 'src/app/services/user-role.service';
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
  role: string;



  constructor(private potentialUserService: PotentialUserService,
    private userRoleService: UserRoleService
  ) {
  }

  ngOnInit(): void {
    this.getUser();
    this.date = moment(this.comment.time, "YYYYMMDD hh:mm").fromNow();
  }

  getUser() {
    this.potentialUserService.getByUserCode(this.comment.userCode).subscribe(x => {
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
}
