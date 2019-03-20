import { Component, OnInit, Input } from '@angular/core';
import { Course } from 'src/app/models/course';

@Component({
  selector: 'app-courses-card',
  templateUrl: './courses-card.component.html',
  styleUrls: ['./courses-card.component.scss']
})
export class CoursesCardComponent implements OnInit {

  @Input() courses: Course[];
  @Input() title: string;
  constructor() { }

  ngOnInit() {
  }

}
