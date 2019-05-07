import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { GradeService } from 'src/app/services/grade-service.service';
import { Grade } from 'src/app/models/grade';

@Component({
  selector: 'app-add-grade-modal-content',
  templateUrl: './add-grade-modal-content.component.html',
  styleUrls: ['./add-grade-modal-content.component.scss']
})
export class AddGradeModalContentComponent implements OnInit {
  grades:Grade[];
  newGrades = new Array <Grade>();
  constructor(@Inject(MAT_DIALOG_DATA) public data: any,public dialogRef: MatDialogRef<AddGradeModalContentComponent>,private gradeService:GradeService) { }

  ngOnInit() {
    this.gradeService.getGrades(this.data.courseId,this.data.studentId,this.data.profId).subscribe(result => this.grades = result);
  }

  onGradesListChanged(event:Grade){
    this.newGrades.push(event);
    this.grades.push(event);
  }

  addGrade(){
    this.newGrades.forEach(element => {
    this.gradeService.addGrade(element).subscribe(result =>{})
    })
  }
}
