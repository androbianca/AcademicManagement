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
export class CategoriesModalComponent implements OnInit {

  courseFormula = new CourseFormula();
  formula : CourseFormula;
  formulaArray= new Array<string>();
  addForm = true;
  gradeFormulaForm = new FormGroup({
    formula: new FormControl(''),
  });

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<DisplayCategoriesComponent>,
    private courseFormulaService: CoureFormulaService,
  ) { 

  }

  ngOnInit(): void {
    this.getFormula(this.data.courseId);
  }

  submit(form) {
    this.courseFormula.courseId = this.data.courseId;
    this.courseFormula.formula = form.value.formula;
    this.addFormula();
  }

  addFormula() {
    this.courseFormulaService.add(this.courseFormula).subscribe(x =>{
      this.formulaArray.push(this.courseFormula.formula);
    })
  }

  getFormula(id) {
    this.courseFormulaService.getByCourseId(id).subscribe(x => {
      this.formula = x
      this.formulaArray.push(this.formula.formula);
    })
  
  }

}
