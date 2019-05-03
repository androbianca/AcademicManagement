import { Component, OnInit, HostBinding } from '@angular/core';

@Component({
  selector: 'app-manage-courses',
  templateUrl: './manage-courses.component.html',
  styleUrls: ['./manage-courses.component.scss']
})
export class ManageCoursesComponent implements OnInit {

  @HostBinding('class') classes = 'manage-courses-container';
  constructor() { }

  ngOnInit() {
  }

}
