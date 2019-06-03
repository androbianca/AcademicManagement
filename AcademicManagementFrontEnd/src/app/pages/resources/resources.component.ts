import { Component, OnInit, HostBinding } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { Role } from 'src/app/models/role-enum';

@Component({
  selector: 'app-resources',
  templateUrl: './resources.component.html',
  styleUrls: ['./resources.component.scss']
})
export class ResourcesComponent implements OnInit {

  @HostBinding('class') classes = 'page-wrapper';
  courseId: string;
  user:UserDetails;
  role : typeof Role = Role;
  isStudent:boolean;
  hasResources = false;

  constructor(private route: ActivatedRoute,
    private currentUser:CurrentUserDetailsService) {
      this.user = this.currentUser.getUser();
      this.isStudent = this.user.userRole == this.role.student ? true : false;
     }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
    });
  }

}
