import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/models/student';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { StudentService } from 'src/app/services/student-service.service';
import { CourseService } from 'src/app/services/course-service.service';
import { CourseWrite } from 'src/app/models/course-write';
import { StudCourseService } from 'src/app/services/stud-course-service.service';
import { StudCourse } from 'src/app/models/stud-course';
import { CourseRead } from 'src/app/models/course-read';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-optional-courses',
  templateUrl: './add-optional-courses.component.html',
  styleUrls: ['./add-optional-courses.component.scss']
})
export class AddOptionalCoursesComponent implements OnInit {

  studs: Student[];
  courses: CourseRead[];
  isDisabled= true;

  addCoursesForm = new FormGroup({
    stud: new FormControl('',Validators.required),
    optionals: new FormControl('',Validators.required),
  });

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  onChanges() {
    this.addCoursesForm.valueChanges.subscribe(() => {
      if (this.addCoursesForm.valid) {
        this.isDisabled = false;
      }
    })
  }

  constructor(private snackBar: MatSnackBar,
    private studService: StudentService, 
    private courseService: CourseService, 
    private studCourseService: StudCourseService) { }

  ngOnInit() {
    this.getStudents();
    this.getOptionalCourses();
    this.onChanges();

  }

  getStudents() {
    this.studService.getAll().subscribe(response => {
      this.studs = response.filter(x => x.isDeleted == false);
    })
  }

  getOptionalCourses() {
    this.courseService.getOptionalCourses().subscribe(response => {
      this.courses = response.filter(x=> x.isDeleted == false);
    })
  }

  addStudCourses(id) {
    var studCourses = new Array<StudCourse>();
    this.courses = this.addCoursesForm.get('optionals').value;
    this.courses.forEach(element => {
      var studCourse = Object.assign({}, new StudCourse());
      studCourse.courseId = element.id;
      studCourse.studId = id;
      studCourses.push(studCourse);
    });
    this.studCourseService.addStudCourses(studCourses).subscribe(response => {
      this.snackBar.open('success')
    }, err => {
      this.snackBar.open('fail')
    });
  }

  submit(form) {
    var id = form.value.stud.id;
    this.addStudCourses(id);
  }
}
