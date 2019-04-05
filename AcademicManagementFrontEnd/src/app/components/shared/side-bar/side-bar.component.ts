
import { Component, OnInit, ChangeDetectorRef, Input } from '@angular/core';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {

  @Input() user: UserDetails;
  fullName: string;
  initials: string;

  constructor(
    private currentUserDetailsService: CurrentUserDetailsService
  ) { this.currentUserDetailsService.getUserObservable().subscribe((user: UserDetails) => {
    if (user && !this.user) {
      this.user=user;
      this.setFullName();

    }
  })}

  setFullName() {
   this.fullName = this.user.lastName + ' ' + this.user.firstName;
   this.initials = this.user.lastName[0] + ' ' + this.user.firstName[0];
  }

  ngOnInit() {

  }
}

