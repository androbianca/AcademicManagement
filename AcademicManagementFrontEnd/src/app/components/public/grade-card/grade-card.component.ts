import { Component, OnInit, Input, HostBinding } from '@angular/core';
import { Grade } from 'src/app/models/grade';

@Component({
  selector: 'app-grade-card',
  templateUrl: './grade-card.component.html',
  styleUrls: ['./grade-card.component.scss']
})
export class GradeCardComponent implements OnInit {

  @Input() grade:Grade;

  @HostBinding('class') classes = 'grade-card';
  constructor() { }

  ngOnInit() {
    
  }

}