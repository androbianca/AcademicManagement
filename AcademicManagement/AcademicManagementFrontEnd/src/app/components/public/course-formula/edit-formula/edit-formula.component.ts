import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CourseFormula } from 'src/app/models/course-formula';
import { FormGroup, FormControl } from '@angular/forms';
import { CoureFormulaService } from 'src/app/services/course-formula.service';

@Component({
  selector: 'app-edit-formula',
  templateUrl: './edit-formula.component.html',
  styleUrls: ['./edit-formula.component.scss']
})
export class EditFormulaComponent implements OnInit {

  @Input() formula: CourseFormula;
  @Output() formClosed = new EventEmitter<any>();

  isDisabled = true;
  errorMessage = 'This fied id required!';
  formulaForm: FormGroup;

  constructor(private courseFormulaService:CoureFormulaService) { }

  ngOnInit(): void {
    console.log(this.formula)
    this.formulaForm = new FormGroup({
      formula: new FormControl(this.formula.formula),
    });
  }


  save(form) {
    // if (!form.get('percentage').hasErrors) {
    // this.category.percentage = form.value.percentage;
    this.formula.formula = form.value.formula;
    this.courseFormulaService.edit(this.formula).subscribe(() => { })
    //  }
  }

  close() {
    this.formClosed.emit(false);
  }
}
