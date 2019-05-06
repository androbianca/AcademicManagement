import { Component, OnInit, HostBinding } from '@angular/core';

@Component({
  selector: 'app-manage-professors',
  templateUrl: './manage-professors.component.html',
  styleUrls: ['./manage-professors.component.scss']
})
export class ManageProfessorsComponent implements OnInit {

  @HostBinding('class') classes = 'manage-profs-container';
  constructor() { }

  ngOnInit() {
  }

}
