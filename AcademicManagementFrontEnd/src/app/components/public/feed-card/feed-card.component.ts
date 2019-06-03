import { Component, OnInit, Input } from '@angular/core';
import { Post } from 'src/app/models/post';
import { StudentService } from 'src/app/services/student-service.service';
import { ProfService } from 'src/app/services/prof-service.service';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { DatePipe } from '@angular/common';
import { Role } from 'src/app/models/role-enum';
import { UserDetails } from 'src/app/models/userDetails';

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
  pipe = new DatePipe('en-US'); // Use your own locale
  date : any;
  role : typeof Role = Role;

  constructor(private studentService: StudentService,
    private profService: ProfService,
    private currentUserDetailsService: CurrentUserDetailsService) {
    this.currentUser = this.currentUserDetailsService.getUser();
  }

  ngOnInit() {
    this.post.role == this.role.student ? this.getStudentDetails() : (this.currentUser.userRole == this.role.professor ? this.getProfDetails() : null)
    this.fullName = this.currentUser.lastName + ' ' + this.currentUser.firstName;
    this.initials = this.currentUser.lastName[0] + ' ' + this.currentUser.firstName[0];
    this.date = this.pipe.transform(this.post.time, 'short');
  }

  getStudentDetails() {
    this.studentService.getById(this.post.userCode).subscribe(x => this.user = x);
  }

  getProfDetails() {
    this.profService.getById(this.post.userCode).subscribe(x => this.user = x);
  }

}
