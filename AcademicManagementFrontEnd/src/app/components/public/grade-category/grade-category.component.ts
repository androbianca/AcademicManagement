import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-grade-category',
  templateUrl: './grade-category.component.html',
  styleUrls: ['./grade-category.component.scss']
})
export class GradeCategoryComponent implements OnInit {

  @Input() courseId: string;
  @Output() formChanged = new EventEmitter<any>();
  @Output() getCourseId = new EventEmitter<any>();

  gradesForm = new FormGroup({
    category: new FormControl('', Validators.required),
    type: new FormControl('1', Validators.required),
    percentage: new FormControl('', [Validators.required, Validators.pattern('^[0-9]+[.]*[0-9]*$')])
  });

  errorMessage = 'This fied is required!';
  isDisabled: boolean = true;

  constructor() { }

  ngOnInit() {
    this.onChanges();
    this.getCourseId.emit(this.courseId);
  }

  onChanges(): void {
    this.gradesForm.valueChanges.subscribe(x => {
      var errors = this.gradesForm.get('percentage').hasError('pattern');
      this.errorMessage = errors ? 'The input should be a number' : 'This fied is required!';
      this.isDisabled = this.gradesForm.valid ? false : true;
      this.formChanged.emit(this.gradesForm);
    })
  }
}
