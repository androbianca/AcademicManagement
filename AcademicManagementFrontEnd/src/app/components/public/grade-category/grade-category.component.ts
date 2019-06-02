import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { GradeCategoryService } from 'src/app/services/grade-category.service';
import { GradeCategory } from 'src/app/models/grade-category';

@Component({
  selector: 'app-grade-category',
  templateUrl: './grade-category.component.html',
  styleUrls: ['./grade-category.component.scss']
})
export class GradeCategoryComponent implements OnInit {

  @Input() courseId: string;
  gradesForm = new FormGroup({
    category: new FormControl('', Validators.required),
    type: new FormControl('', Validators.required),
    percentage: new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')])
  });
  gradeCategory = new GradeCategory();
  errorMessage= 'This fied is required!';
  isDisabled: boolean = true;

  constructor(private gradeCategoryService: GradeCategoryService) { }

  ngOnInit() {
  }
  onChanges(): void {
    this.gradesForm.valueChanges.subscribe(x=> {
      var errors = this.gradesForm.get('percentage').hasError('pattern');
      this.errorMessage = errors ? 'The input should be a number' : 'This fied is required!';
      this.isDisabled = this.gradesForm.valid ? false :true;
    })
  }

  save(form) {
    this.gradeCategory.courseId = this.courseId;
    this.gradeCategory.name = form.value.category;
    this.gradeCategory.percentage = form.value.percentage;
    var value = form.value.type ? true : false;
    this.gradeCategory.isCourseCategory = value;

    this.gradeCategoryService.addGradeCategory(this.gradeCategory).subscribe(x=> {});
  }

}
