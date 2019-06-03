import { Component, OnInit, HostBinding } from '@angular/core';

@Component({
  selector: 'app-manage-stud',
  templateUrl: './manage-stud.component.html',
  styleUrls: ['./manage-stud.component.scss']
})
export class ManageStudComponent {

  @HostBinding('class') classes = 'manage-studs-container';
  remove: boolean;
  add: boolean = true;
  update: boolean;
  courses: boolean;

  selectAction(number: string) {
    this.add = number == '1';
    this.remove = number == '2';
    this.update = number == '3';
    this.courses = number == '4';

  }
}
