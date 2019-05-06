import { Component, OnInit, HostBinding, Input } from "@angular/core";
import { Router } from '@angular/router';
import { CourseRead } from 'src/app/models/course-read';

@Component({
  selector: "app-course-card",
  templateUrl: "./course-card.component.html",
  styleUrls: ["./course-card.component.scss"]
})
export class CourseCardComponent implements OnInit {
  @Input() course: CourseRead;
  @Input() route:string;
  @Input() message:string;

  @HostBinding('class') classes = 'card';
  initials :string = "";

  constructor(private router: Router) {}

  ngOnInit() {
    console.log(this.course)
    let x = this.course.name.split(" ");
    x.forEach(el => {
      this.initials += el[0].toLocaleUpperCase();
    })
    }

    goTo(){
      this.router.navigate([this.route + `${this.course.id}`]);
    }
  }

