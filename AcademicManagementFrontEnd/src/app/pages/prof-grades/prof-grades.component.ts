import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student-service.service';

@Component({
  selector: 'app-prof-grades',
  templateUrl: './prof-grades.component.html',
  styleUrls: ['./prof-grades.component.scss']
})
export class ProfGradesComponent implements OnInit {

  constructor(private studentService:StudentService) { }

  ngOnInit() {


    this.studentService.getStudentsByProf();
  }

}
