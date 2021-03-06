import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GradeCategory } from 'src/app/models/grade-category';
import { GradeCategoryService } from 'src/app/services/grade-category.service';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-grade-category-modal-component',
  templateUrl: './grade-category-modal-component.component.html',
  styleUrls: ['./grade-category-modal-component.component.scss']
})
export class GradeCategoryModalComponentComponent {

  gradeCategory = new GradeCategory();
  courseId: string;
  form: FormControl;
  isDisabled = true;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private route: ActivatedRoute,
    public dialogRef: MatDialogRef<GradeCategoryModalComponentComponent>,
    private gradeCategoryService: GradeCategoryService,
    private snackBar: MatSnackBar) {
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  getCourseId(event) {
    this.courseId = event;
  }

  onFormChange(event) {
    this.form = event;
    if (event.valid) {
      this.isDisabled = false;
      this.gradeCategory.courseId = this.courseId;
      this.gradeCategory.name = event.value.category;
    //is.gradeCategory.percentage = event.value.percentage;
      var value = event.value.type ? true : false;
     // this.gradeCategory.isCourseCategory = value;
    }
  }

  save() {
    if (this.form.valid) {
      this.gradeCategoryService.addGradeCategory(this.gradeCategory).subscribe(x => {
        this.snackBar.open('success')
      },
        err => {
          this.snackBar.open('fail')
        });
    }
  }
}
