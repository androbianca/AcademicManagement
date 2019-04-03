import { Component, OnInit, HostBinding, Input } from "@angular/core";
import { InitialStylingValuesIndex } from '@angular/core/src/render3/interfaces/styling';

@Component({
  selector: "app-course-card",
  templateUrl: "./course-card.component.html",
  styleUrls: ["./course-card.component.scss"]
})
export class CourseCardComponent implements OnInit {
  @Input() name: string;
  initials :string = " ";

  constructor() {}

  ngOnInit() {
    let x = this.name.split(" ");
    x.forEach(el => {
      this.initials += el[0].toLocaleUpperCase();
    })

    }
  }

