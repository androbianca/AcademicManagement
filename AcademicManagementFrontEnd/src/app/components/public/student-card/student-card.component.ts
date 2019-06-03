import { Component, OnInit, HostBinding, Input, Output, Injectable, HostListener } from '@angular/core';
import { AddGradeModalContentComponent } from '../add-grade-modal-content/add-grade-modal-content.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-student-card',
  templateUrl: './student-card.component.html',
  styleUrls: ['./student-card.component.scss']
})

export class StudentCardComponent implements OnInit {

  @Input() student;
  @Input() courseId;
  @Input() profId;

  @HostBinding('class') classes = 'student-card';
  @HostListener('click', ['$event.target'])
  onClick() {
    this.openModal();
  }

  public name: string;
  public initials: string;
  public isAddGradesOpen: boolean = false;

  constructor(public dialog: MatDialog) { }

  getName() {
    this.name = this.student.lastName + ' ' + this.student.firstName;
  }

  getInitials() {
    this.initials = this.student.lastName[0] + ' ' + this.student.firstName[0];
  }

  openModal() {
    const dialogRef = this.dialog.open(AddGradeModalContentComponent, {
      width: '390px',
      height: '640px',
      data: { studentId: this.student.id, profId: this.profId, courseId: this.courseId }
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  ngOnInit() {
    this.getName();
    this.getInitials();
  }
}
