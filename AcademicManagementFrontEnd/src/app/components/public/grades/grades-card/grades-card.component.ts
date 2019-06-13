import { Component, Input } from '@angular/core';
import { Grade } from 'src/app/models/grade';

@Component({
  selector: 'app-grades-card',
  templateUrl: './grades-card.component.html',
  styleUrls: ['./grades-card.component.scss']
})
export class GradesCardComponent {

  @Input() grades: Grade[];

}
