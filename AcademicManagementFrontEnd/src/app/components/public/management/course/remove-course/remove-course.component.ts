import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course-service.service';
import { CourseRead } from 'src/app/models/course-read';
import { FormGroup, FormControl, Validators, FormGroupDirective, NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorStateMatcher } from '@angular/material/core';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-remove-course',
  templateUrl: './remove-course.component.html',
  styleUrls: ['./remove-course.component.scss']
})
export class RemoveCourseComponent implements OnInit {

  courses: CourseRead[];
  errorMessage = "This field is required!";
  isDisabled = true;
  matcher = new MyErrorStateMatcher();

  removeCourseForm = new FormGroup({
    course: new FormControl('',Validators.required),
  });

  constructor(private courseService: CourseService, private snackBar: MatSnackBar) {
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  getCourses() {
    this.courseService.getAll().subscribe(response => {
      this.courses = response;
    })
  }
  ngOnInit() {
    this.getCourses();
    this.onChanges()

  }

  onChanges() {
    this.removeCourseForm.valueChanges.subscribe(() => {
      if (this.removeCourseForm.valid) {
        this.isDisabled = false;
      }
    })
  }

  submit(form) {
    var course = form.value.course;
    this.courseService.removeCourse(course.id).subscribe(() => {this.snackBar.open('success')
  }, err =>{this.snackBar.open('fail')
});
  }
}
