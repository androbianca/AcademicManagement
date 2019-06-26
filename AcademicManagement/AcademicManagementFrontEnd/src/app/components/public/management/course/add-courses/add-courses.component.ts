import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CourseWrite } from 'src/app/models/course-write';
import { CourseService } from 'src/app/services/course-service.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-courses',
  templateUrl: './add-courses.component.html',
  styleUrls: ['./add-courses.component.scss']
})
export class AddCoursesComponent implements OnInit {

  course = new CourseWrite;
  errorMessage = "This field is required!";
  isDisabled = true;

  addCourseForm = new FormGroup({
    name: new FormControl('', Validators.required),
    year: new FormControl('', Validators.required),
    semester: new FormControl('', Validators.required),
    package: new FormControl('')
  });

  constructor(private courseService: CourseService, private snackBar: MatSnackBar) {
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  ngOnInit() {
    this.onChanges()
  }

  onChanges() {
    this.addCourseForm.valueChanges.subscribe(() => {
      if (this.addCourseForm.valid) {
        this.isDisabled = false;
      }
    })
  }

  addCourse() {
    this.courseService.addCourse(this.course).subscribe(result => {
      this.snackBar.open('success')
    }, err => {
      this.snackBar.open('fail')
    })
  }

  submit(form) {
    if (form.valid) {
      this.course.name = form.value.name;
      this.course.package = form.value.package;
      this.course.semester = form.value.semester;
      this.course.year = form.value.year;
      this.addCourse();
    }
  }
}
