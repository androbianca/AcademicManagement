import { Component, OnInit, HostBinding, Input } from "@angular/core";
import { InitialStylingValuesIndex } from '@angular/core/src/render3/interfaces/styling';
import { Router } from '@angular/router';

@Component({
  selector: "app-course-card",
  templateUrl: "./course-card.component.html",
  styleUrls: ["./course-card.component.scss"]
})
export class CourseCardComponent implements OnInit {
  @Input() name: string;
  @Input() route:string;
  @Input() message:string;
  initials :string = "";

  constructor(private router: Router) {}

  ngOnInit() {
    let x = this.name.split(" ");
    x.forEach(el => {
      this.initials += el[0].toLocaleUpperCase();
    })
    }

    goTo(){
      console.log(this.route)
      this.router.navigate([this.route]);
    }
  }

