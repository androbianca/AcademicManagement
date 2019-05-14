import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/models/student';
import { FormGroup, FormControl } from '@angular/forms';
import { StudentService } from 'src/app/services/student-service.service';

@Component({
  selector: 'app-remove-student',
  templateUrl: './remove-student.component.html',
  styleUrls: ['./remove-student.component.scss']
})
export class RemoveStudentComponent implements OnInit {

  studs:Student[];
  
  removeStudForm = new FormGroup({
    stud: new FormControl(''),
  });

  constructor(private studService:StudentService) { }

  ngOnInit() {
    this.getStudents();
  }

  getStudents(){
  this.studService.getAll().subscribe(response => {
    this.studs = response;
  })
  }

  removeStudent(id:string){
   this.studService.removeStudent(id).subscribe(response => {
     console.log(response);
   })
  }

  submit(form){
    var id = form.value.stud.id;
    this.removeStudent(id);
  }

}
