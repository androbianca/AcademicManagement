import { Component, OnInit, Input, HostBinding, EventEmitter, Output } from '@angular/core';
import { Grade } from 'src/app/models/grade';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { GradeService } from 'src/app/services/grade-service.service';
import { Role } from 'src/app/models/role-enum';

@Component({
  selector: 'app-edit-grade',
  templateUrl: './edit-grade.component.html',
  styleUrls: ['./edit-grade.component.scss']
})
export class EditGradeComponent implements OnInit {

  @Input() grade: Grade;
  @HostBinding('class') classes = 'add-grade-card';
  @Output() formClose = new EventEmitter<any>();

  isDisabled = true;
  errorMessage = 'This fied id required!';

  gradesForm = new FormGroup({
    value: new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')])
  });

  constructor(private gradeService: GradeService) { }

  ngOnInit(): void {
    this.onChanges();
  }

  onChanges(): void {
    this.gradesForm.valueChanges.subscribe(x => {
      var errors = this.gradesForm.get('value').hasError('pattern');
      this.errorMessage = errors ? 'The input should be a number' : 'This fied is required!';
      this.isDisabled = this.gradesForm.valid ? false : true;
    })
  }

  save(gradesForm) {
    this.grade.value = gradesForm.value.value;
    this.gradeService.updateGrade(this.grade).subscribe(x =>{})
  }

  closeForm() {
    this.formClose.emit("Close");
  }
}
