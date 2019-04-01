import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course-service.service';
import { Course } from 'src/app/models/course';

@Component({
  selector: 'app-grades',
  templateUrl: './grades.component.html',
  styleUrls: ['./grades.component.scss']
})
export class GradesComponent implements OnInit {

  courses: Course[];
  firstYearCourses: Course[];
  secondYearCourses: Course[];
  thirdYearCourses: Course[];
  constructor(private courseService: CourseService) { 
    this.getCourses();
  }

  ngOnInit() {  
  }

  getCourses() {
    this.courseService.getAll().subscribe((response: Course[]) => {
      this.firstYearCourses = response.filter(x => x.year == '1');
      this.secondYearCourses = response.filter(x => x.year == '2');
      this.thirdYearCourses = response.filter(x => x.year == '3');
    });
  }

}
