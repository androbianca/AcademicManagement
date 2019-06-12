import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { GradeCategory } from 'src/app/models/grade-category';
import { GradeCategoryService } from 'src/app/services/grade-category.service';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.scss']
})
export class EditCategoryComponent implements OnInit {

  @Input() category: GradeCategory;
  @Output() formClosed = new EventEmitter<any>();

  isDisabled = true;
  errorMessage = 'This fied id required!';
  categoryForm: FormGroup;

  constructor(private gradeCategoryService: GradeCategoryService) { }

  ngOnInit(): void {
    this.categoryForm = new FormGroup({
      name: new FormControl(this.category.name),
      // percentage: new FormControl(this.category.percentage, Validators.pattern('^[0-9]*$'))
    });

    this.onChanges();
  }

  onChanges(): void {
    this.categoryForm.valueChanges.subscribe(x => {
      var errors = this.categoryForm.get('percentage').hasError('pattern');
      this.errorMessage = errors ? 'The input should be a number' : 'This fied is required!';
      this.isDisabled = this.categoryForm.valid ? false : true;
    })
  }

  save(form) {
    // if (!form.get('percentage').hasErrors) {
    // this.category.percentage = form.value.percentage;
    this.category.name = form.value.name;
    this.gradeCategoryService.edit(this.category).subscribe(() => { })
    //  }
  }

  close() {
    this.formClosed.emit(false);
  }
}
