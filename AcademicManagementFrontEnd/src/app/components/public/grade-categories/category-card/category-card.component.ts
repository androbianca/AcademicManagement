import { Component, OnInit, Input } from '@angular/core';
import { GradeCategory } from 'src/app/models/grade-category';
import { Role } from 'src/app/models/role-enum';
import { UserDetails } from 'src/app/models/userDetails';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';

@Component({
  selector: 'app-category-card',
  templateUrl: './category-card.component.html',
  styleUrls: ['./category-card.component.scss']
})
export class CategoryCardComponent {

  @Input() category:GradeCategory;
  role: typeof Role = Role;
  isStudent: boolean;
  user: UserDetails;
  open = false;

  constructor(private currentUser: CurrentUserDetailsService) {
    this.user = this.currentUser.getUser();
    this.isStudent = this.user.userRole == this.role.student ? true : false;
  }

  openForm() {
    this.open = true;
  }

  onFormClose(event){
    this.open= false;
  }

}
