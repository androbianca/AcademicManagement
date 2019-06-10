import { Component, Input, HostBinding } from '@angular/core';
import { Grade } from 'src/app/models/grade';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { UserDetails } from 'src/app/models/userDetails';
import { Role } from 'src/app/models/role-enum';

@Component({
  selector: 'app-grade-card',
  templateUrl: './grade-card.component.html',
  styleUrls: ['./grade-card.component.scss']
})
export class GradeCardComponent {
  role: typeof Role = Role;
  isStudent: boolean;
  user: UserDetails;
  open = false;

  constructor(private currentUser: CurrentUserDetailsService) {
    this.user = this.currentUser.getUser();
    this.isStudent = this.user.userRole == this.role.student ? true : false;

  }
  @Input() grade: Grade;

  @HostBinding('class') classes = 'grade-card';


  openForm() {
    this.open = true;
  }

  onformClose(event) {
    this.open = false;
  }
}
