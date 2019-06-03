import { Component, OnInit, HostBinding } from '@angular/core';

@Component({
  selector: 'app-manage-professors',
  templateUrl: './manage-professors.component.html',
  styleUrls: ['./manage-professors.component.scss']
})
export class ManageProfessorsComponent implements OnInit {

  @HostBinding('class') classes = 'manage-profs-container';

  remove: boolean;
  add: boolean = true;
  update: boolean;
  courses: boolean;
  constructor() { }

  ngOnInit() {
  }

  selectAction(number: string) {
    this.add = number == '1';
    this.remove = number == '2';
    this.update = number == '3';
    this.courses = number == '4';
  }

}
