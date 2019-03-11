import { Component, OnInit, ChangeDetectorRef } from "@angular/core";
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { User } from 'src/app/models/user';

@Component({
  selector: "app-side-bar",
  templateUrl: "./side-bar.component.html",
  styleUrls: ["./side-bar.component.scss"]
})
export class SideBarComponent implements OnInit {
  user: User;
  constructor(private currentUserDetailsService: CurrentUserDetailsService, private changeDetectorRef: ChangeDetectorRef) { 
    this.user = currentUserDetailsService.getUser();
   
  }

  ngOnInit() {
    console.log(this.user);
   
  
}}
