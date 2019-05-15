
import { Component, OnInit, ChangeDetectorRef, Input } from '@angular/core';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {

  user: UserDetails;
  fullName: string;
  initials: string;
  route: string;

  constructor(
    private currentUserDetailsService: CurrentUserDetailsService
  ) { 
    
    this.user = this.currentUserDetailsService.getUser();
    this.setFullName();  
  }

  setFullName() {
   this.fullName = this.user.lastName + ' ' + this.user.firstName;
   this.initials = this.user.lastName[0] + ' ' + this.user.firstName[0];
  }

  ngOnInit() {
    this.route = `professors/${this.user.id}`;
  }
}

