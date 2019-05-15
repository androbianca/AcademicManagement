import { Component, OnInit, HostBinding } from '@angular/core';

@Component({
  selector: 'app-manage-groups',
  templateUrl: './manage-groups.component.html',
  styleUrls: ['./manage-groups.component.scss']
})
export class ManageGroupsComponent implements OnInit {

  @HostBinding('class') classes = "manage-groups-container";
  remove:boolean;
  add: boolean = true;
  update:boolean;
  constructor() { }

  ngOnInit() {
  }

  selectAction(number:string){
     this.add = number == '1';
     this.remove = number == '2';
     this.update = number == '3';
  }

}
