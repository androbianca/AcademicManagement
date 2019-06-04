import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/models/student';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { StudentService } from 'src/app/services/student-service.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-remove-student',
  templateUrl: './remove-student.component.html',
  styleUrls: ['./remove-student.component.scss']
})
export class RemoveStudentComponent implements OnInit {

  studs: Student[];

  removeStudForm = new FormGroup({
    stud: new FormControl('', Validators.required),
  });
  isDisabled= true;

  constructor(private studService: StudentService, private snackBar: MatSnackBar) { }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  ngOnInit() {
    this.getStudents();
    this.onChanges();
  }

  onChanges() {
    this.removeStudForm.valueChanges.subscribe(() => {
      if (this.removeStudForm.valid) {
        this.isDisabled = false;
      }
    })
  }


  getStudents() {
    this.studService.getAll().subscribe(response => {
      this.studs = response.filter(x=> x.isDeleted == false);
    })
  }

  removeStudent(id: string) {
    this.studService.removeStudent(id).subscribe(response => {
      this.snackBar.open('success')
    }, err => {
      this.snackBar.open('fail')
    });
  }

  submit(form) {
    var id = form.value.stud.id;
    this.removeStudent(id);
  }

}
