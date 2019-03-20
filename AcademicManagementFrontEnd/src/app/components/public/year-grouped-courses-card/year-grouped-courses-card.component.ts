import { Component, OnInit, Input } from '@angular/core';
import { Course } from 'src/app/models/course';

@Component({
  selector: 'app-year-grouped-courses-card',
  templateUrl: './year-grouped-courses-card.component.html',
  styleUrls: ['./year-grouped-courses-card.component.scss']
})
export class YearGroupedCoursesCardComponent implements OnInit {

  @Input() courses: Course[];
  @Input() title: string;
  firstSemester: Course[];
  seconSemester: Course[];

  constructor() { }

  ngOnInit() {

    this.groupBySemester();
  }

  groupBySemester() {
    
      this.firstSemester = this.courses.filter(x => x.semester == '1');
      this.seconSemester = this.courses.filter(x => x.semester == '2');
  }

}
