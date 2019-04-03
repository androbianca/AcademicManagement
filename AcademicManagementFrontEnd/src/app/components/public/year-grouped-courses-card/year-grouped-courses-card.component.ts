import { Component, OnInit, Input } from '@angular/core';
import { Course } from 'src/app/models/course';

@Component({
  selector: 'app-year-grouped-courses-card',
  templateUrl: './year-grouped-courses-card.component.html',
  styleUrls: ['./year-grouped-courses-card.component.scss']
})
export class YearGroupedCoursesCardComponent implements OnInit {

  @Input() courses: Course[];
  orderedCourses: Course[];

  constructor() { }

  ngOnInit() {
    this.orderedCourses = this.courses.sort((n1, n2) => {
      if (n1.semester > n2.semester) {
        return 1;
      }
      else return -1;
    })
  }

}
