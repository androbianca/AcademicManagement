import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { GradeService } from 'src/app/services/grade-service.service';
import { Grade } from 'src/app/models/grade';
import { MatSnackBar } from '@angular/material/snack-bar';
import { runInThisContext } from 'vm';

@Component({
  selector: 'app-add-grade-modal-content',
  templateUrl: './add-grade-modal-content.component.html',
  styleUrls: ['./add-grade-modal-content.component.scss']
})
export class AddGradeModalContentComponent implements OnInit {
  grades:Grade[];
  newGrades = new Array <Grade>();
  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
  public dialogRef: MatDialogRef<AddGradeModalContentComponent>,
  private gradeService:GradeService,
  private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.gradeService.getGrades(this.data.courseId,this.data.studentId).subscribe(result => this.grades = result);
  }

  onGradesListChanged(event:Grade){
    this.newGrades.push(event);
    this.grades.push(event);
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  addGrade(){
    this.newGrades.forEach(element => {
    this.gradeService.addGrade(element).subscribe(result =>{this.snackBar.open('success')}, err => {
      this.snackBar.open('fail')
    })
    })
  }
}
