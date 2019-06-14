import { Component, OnInit, Input } from '@angular/core';
import { CourseFormula } from 'src/app/models/course-formula';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { CoureFormulaService } from 'src/app/services/course-formula.service';
import { runInThisContext } from 'vm';

@Component({
  selector: 'app-add-formula',
  templateUrl: './add-formula.component.html',
  styleUrls: ['./add-formula.component.scss']
})
export class AddFormulaComponent implements OnInit {

  @Input() courseId: string;
  courseFormula = new CourseFormula();
  formula : CourseFormula;
  formulaArray= new Array<CourseFormula>();
  addForm = true;
  open = false;
  gradeFormulaForm = new FormGroup({
  formula: new FormControl('',[Validators.pattern('^([0-9A-Za-z]*[+\\-*/()\\.)]*)*$')]),
  });
  
  constructor(private courseFormulaService:CoureFormulaService) { }

  ngOnInit() {
    this.getFormula(this.courseId);
  }

  submit(form) {
    this.courseFormula.courseId = this.courseId;
    this.courseFormula.formula = form.value.formula;
    this.addFormula();
  }

  addFormula() {
    this.courseFormulaService.add(this.courseFormula).subscribe(x =>{
      this.formulaArray.push(this.courseFormula);
    })
  }

  getFormula(id) {
    this.courseFormulaService.getByCourseId(id).subscribe(x => {
      if(x){
      this.formula = x

      this.formulaArray.push(this.formula);}
    })
  }
  openForm(){
    this.open = true;
  }

  onFormClose(event){
    this.open = false;
  }
}
