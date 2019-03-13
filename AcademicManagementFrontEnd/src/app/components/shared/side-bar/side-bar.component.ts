import { Component, OnInit, ChangeDetectorRef } from "@angular/core";
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';

@Component({
  selector: "app-side-bar",
  templateUrl: "./side-bar.component.html",
  styleUrls: ["./side-bar.component.scss"]
})
export class SideBarComponent implements OnInit {

  fullName: string;
  year: string;
  group: string;
  private user = new UserDetails();

  constructor(private currentUserDetailsService: CurrentUserDetailsService, private changeDetectorRef: ChangeDetectorRef) {
    this.user = currentUserDetailsService.getUser();
  }

  setFullName() {
    this.fullName = this.user.LastName + " " + this.user.FirstName;
  }

  setYear() {
    this.year = "Year " + this.user.Year;
  }

  setGroup() {

    this.group = "Group " + this.user.Group;
  }

  ngOnInit() {
    this.setFullName();
    this.setGroup();
    this.setYear();
  }
}
