import { Component, OnInit, HostBinding, Input, Output, Injectable } from '@angular/core';
import { EventEmitter } from '@angular/core';
import {MatDialogModule, MatDialogRef, MatDialog} from '@angular/material/dialog';
import { GradesCardComponent } from '../grades-card/grades-card.component';
import { AddGradeModalContentComponent } from '../add-grade-modal-content/add-grade-modal-content.component';

@Component({
  selector: 'app-student-card',
  templateUrl: './student-card.component.html',
  styleUrls: ['./student-card.component.scss']
})

export class StudentCardComponent implements OnInit {

  @Input() student; 
  @Input() courseId;
  @Input() profId;

  public name: string;
  public initials:string;
  public isAddGradesOpen: boolean = false;
  @HostBinding('class') classes = 'student-card';
  constructor(public dialog: MatDialog) {

   }

  getName(){
    this.name = this.student.lastName + ' ' + this.student.firstName;
  }

  getInitials(){
    this.initials = this.student.lastName[0] + ' ' + this.student.firstName[0];
  }

  onArrowClick(){
    
    const dialogRef = this.dialog.open(AddGradeModalContentComponent, {
      width: '350px',
      height: '500px',
      data: { studentId: this.student.id, profId : this.profId , courseId : this.courseId }
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }
  ngOnInit() {
    this.getName();
    this.getInitials();
  }

}
