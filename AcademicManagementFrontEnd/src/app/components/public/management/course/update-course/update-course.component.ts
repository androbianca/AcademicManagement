import { Component, OnInit } from '@angular/core';
import { CourseWrite } from 'src/app/models/course-write';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { CourseService } from 'src/app/services/course-service.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CourseRead } from 'src/app/models/course-read';

@Component({
  selector: 'app-update-course',
  templateUrl: './update-course.component.html',
  styleUrls: ['./update-course.component.scss']
})
export class UpdateCourseComponent implements OnInit {

  course = new CourseWrite;
  errorMessage = "This field is required!";
  isDisabled = true;
  courses: CourseRead[];
  selectedCourse = new CourseRead();

  addCourseForm = new FormGroup({
    course: new FormControl(''),
    name: new FormControl(this.selectedCourse.name, Validators.required),
    year: new FormControl(this.selectedCourse.year, Validators.required),
    semester: new FormControl(this.selectedCourse.semester, Validators.required),
    package: new FormControl(this.selectedCourse.package)
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
    this.getCourses();
  }

  getCourses() {
    this.courseService.getAll().subscribe(response => {
      this.courses = response;
    })
  }

  onChanges() {
    this.addCourseForm.valueChanges.subscribe(() => {
      this.selectedCourse = this.addCourseForm.value.course;
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
