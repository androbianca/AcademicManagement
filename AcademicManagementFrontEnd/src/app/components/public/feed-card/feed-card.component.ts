import { Component, OnInit, Input } from '@angular/core';
import { Post } from 'src/app/models/post';
import { StudentService } from 'src/app/services/student-service.service';
import { ProfService } from 'src/app/services/prof-service.service';
import { UserDetails } from 'src/app/models/userDetails';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-feed-card',
  templateUrl: './feed-card.component.html',
  styleUrls: ['./feed-card.component.scss']
})
export class FeedCardComponent implements OnInit {

  @Input() post: Post;
  user: any;
  fullName: string;
  initials:string;
  pipe = new DatePipe('en-US'); // Use your own locale
  date : any;

  constructor(private studentService: StudentService,
    private profService: ProfService,
    private currentUserDetailsService: CurrentUserDetailsService) {
    this.user = this.currentUserDetailsService.getUser();
  }

  ngOnInit() {
    this.post.role == "Student" ? this.getStudentDetails() : (this.user.userRole == "Professor" ? this.getProfDetails() : null)
    this.fullName = this.user.lastName + ' ' + this.user.firstName;
    this.initials = this.user.lastName[0] + ' ' + this.user.firstName[0];
    this.date = this.pipe.transform(this.post.time, 'short');
  }

  getStudentDetails() {
    this.studentService.getById(this.post.userCode).subscribe(x => this.user = x);
  }

  getProfDetails() {
    this.profService.getById(this.post.userCode).subscribe(x => this.user = x);
  }

}
