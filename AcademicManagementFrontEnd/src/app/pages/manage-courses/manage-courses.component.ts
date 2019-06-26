import { Component, OnInit, HostBinding } from '@angular/core';

@Component({
  selector: 'app-manage-courses',
  templateUrl: './manage-courses.component.html',
  styleUrls: ['./manage-courses.component.scss']
})
export class ManageCoursesComponent {

  @HostBinding('class') classes = 'manage-courses-container';
  remove: boolean;
  add: boolean = true;
  update: boolean;
  optionals : boolean;

  selectAction(number: string) {
    this.add = number == '1';
    this.remove = number == '2';
    this.update = number == '3';
    this.optionals = number == '4';
  }

}
