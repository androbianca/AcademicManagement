import { Component, OnInit, HostBinding } from '@angular/core';

@Component({
  selector: 'app-manage-stud',
  templateUrl: './manage-stud.component.html',
  styleUrls: ['./manage-stud.component.scss']
})
export class ManageStudComponent implements OnInit {

  @HostBinding('class') classes = 'manage-studs-container';
  constructor() { }

  ngOnInit() {
  }

}
