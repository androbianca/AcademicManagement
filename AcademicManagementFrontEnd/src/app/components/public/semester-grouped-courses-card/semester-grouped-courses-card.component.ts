import { Component, OnInit, Input } from "@angular/core";
import { Course } from "src/app/models/course";

@Component({
  selector: "app-semester-grouped-courses-card",
  templateUrl: "./semester-grouped-courses-card.component.html",
  styleUrls: ["./semester-grouped-courses-card.component.scss"]
})
export class SemesterGroupedCoursesCardComponent implements OnInit {
  @Input() courses: Course[];
  @Input() title: string;
  constructor() {}

  ngOnInit() {}
}
