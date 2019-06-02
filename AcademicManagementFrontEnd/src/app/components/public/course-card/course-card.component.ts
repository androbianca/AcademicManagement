import { Component, OnInit, HostBinding, Input, HostListener } from "@angular/core";
import { Router } from '@angular/router';
import { CourseRead } from 'src/app/models/course-read';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';

@Component({
  selector: "app-course-card",
  templateUrl: "./course-card.component.html",
  styleUrls: ["./course-card.component.scss"]
})
export class CourseCardComponent implements OnInit {
  @Input() course: CourseRead;
  @Input() route: string;
  @Input() message: string;

  @HostBinding('class') classes = 'card';
  @HostListener('click', ['$event.target'])
  onClick() {
    this.goTo();
 }
  initials: string = "";
  user:UserDetails;

  constructor(private router: Router,private currentUserService:CurrentUserDetailsService) { 
    this.user = this.currentUserService.getUser();
  }

  ngOnInit() {
    let name = this.course.name.split(" ");
    name.forEach(el => {
      this.initials += el[0].toLocaleUpperCase();
    })
  }

  goTo() {
    this.router.navigate([this.route + `${this.course.id}`]);
  }
}

