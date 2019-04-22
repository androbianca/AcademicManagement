import { Component, OnInit, HostBinding, Input, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-student-card',
  templateUrl: './student-card.component.html',
  styleUrls: ['./student-card.component.scss']
})
export class StudentCardComponent implements OnInit {

  @Input() student;
  @Output() addGradesChanged : EventEmitter<any> =  new EventEmitter();
  public name: string;
  public initials:string;
  public isAddGradesOpen: boolean = false;
  @HostBinding('class') classes = 'student-card';
  constructor() {

   }

  getName(){
    this.name = this.student.lastName + ' ' + this.student.firstName;
  }

  getInitials(){
    this.initials = this.student.lastName[0] + ' ' + this.student.firstName[0];
  }

  onArrowClick(){
    this.isAddGradesOpen = !this.isAddGradesOpen;
    this.addGradesChanged.emit(this.isAddGradesOpen);
  }
  ngOnInit() {
    this.getName();
    this.getInitials();
  }

}
