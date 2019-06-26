import { Component, OnInit, Input } from '@angular/core';
import { CourseWrite } from 'src/app/models/course-write';
import { CourseRead } from 'src/app/models/course-read';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CourseService } from 'src/app/services/course-service.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-manage-course-card',
  templateUrl: './course-card.component.html',
  styleUrls: ['./course-card.component.scss']
})
export class ManageCourseCardComponent implements OnInit {
  @Input() item;
  
  open = false;
  course = new CourseRead;
  isDisabled = true;
  addCourseForm: FormGroup;

  constructor(private courseService: CourseService, private snackBar: MatSnackBar) {
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  ngOnInit() {
    console.log(this.item)
    this.addCourseForm = new FormGroup({
      name: new FormControl(this.item.name, Validators.required),
      year: new FormControl(this.item.year, Validators.required),
      semester: new FormControl(this.item.semester, Validators.required),
      package: new FormControl(this.item.package)
    });
    this.onChanges()
  }

  onChanges() {
    this.addCourseForm.valueChanges.subscribe(() => {
      if (this.addCourseForm.valid) {
        this.isDisabled = false;
      }
    })
  }

  updateCourse() {
    this.courseService.editCourse(this.item).subscribe(result => {
      this.snackBar.open('success')
    }, err => {
      this.snackBar.open('fail')
    })
  }

  submit(form) {
    debugger
    if (form.valid) {
      this.item.name = form.value.name;
      this.item.package = form.value.package
      this.item.semester = form.value.semester;
      this.item.year = form.value.year;
      this.updateCourse();
    }
  }


  toggle() {
    this.open = !this.open;
  }

}
