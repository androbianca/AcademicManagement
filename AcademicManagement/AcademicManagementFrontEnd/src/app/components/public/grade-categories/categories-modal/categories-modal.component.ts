import { Component, OnInit, Inject } from '@angular/core';
import { DisplayCategoriesComponent } from '../display-categories/display-categories.component';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CourseFormula } from 'src/app/models/course-formula';
import { CoureFormulaService } from 'src/app/services/course-formula.service';

@Component({
  selector: 'app-categories-modal',
  templateUrl: './categories-modal.component.html',
  styleUrls: ['./categories-modal.component.scss']
})
export class CategoriesModalComponent {

 

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<DisplayCategoriesComponent>,
  ){}

}
