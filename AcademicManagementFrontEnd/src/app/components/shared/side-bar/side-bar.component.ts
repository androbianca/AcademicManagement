import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {
  fullName: string;
  year: string;
  group: string;
  private user = new UserDetails();

  constructor(
    private currentUserDetailsService: CurrentUserDetailsService,
    private changeDetectorRef: ChangeDetectorRef
  ) {

  }

  setFullName() {
    this.fullName = this.user.lastName + ' ' + this.user.firstName;
  }

  setYear() {
    this.year = 'Year ' + this.user.year;
  }

  setGroup() {
    this.group = 'Group ' + this.user.group;
  }

  ngOnInit() {
    this.currentUserDetailsService.getUserObservable().subscribe ((user:UserDetails) => {
      if(user){
        this.user = user;
        this.setFullName();
        this.setGroup();
        this.setYear();
      }
    })

  }
}
