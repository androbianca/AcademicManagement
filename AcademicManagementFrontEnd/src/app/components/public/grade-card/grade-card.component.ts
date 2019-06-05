import { Component, Input, HostBinding } from '@angular/core';
import { Grade } from 'src/app/models/grade';

@Component({
  selector: 'app-grade-card',
  templateUrl: './grade-card.component.html',
  styleUrls: ['./grade-card.component.scss']
})
export class GradeCardComponent {

  @Input() grade:Grade;

  @HostBinding('class') classes = 'grade-card';

  open = false;

  toggle(){
   this.open = !this.open;
  }
}
