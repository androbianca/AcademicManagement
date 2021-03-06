import { Component } from "@angular/core";
import { CourseService } from "src/app/services/course-service.service";
import { CourseRead } from 'src/app/models/course-read';

@Component({
  selector: "app-grades",
  templateUrl: "./stud-grades.component.html",
  styleUrls: ["./stud-grades.component.scss"]
})

export class StudGradesComponent {
  courses: CourseRead[];
  firstYearCourses: CourseRead[];
  secondYearCourses: CourseRead[];
  thirdYearCourses: CourseRead[];
  firstYear = true;
  scondYear = false;
  thirdYear = false;
  hasCourses1 = false;
  hasCourses2 = false;
  hasCourses3 = false;
  
  constructor(private courseService: CourseService) {
    this.getStudCourses();
  }

  getStudCourses() {
    this.courseService.getStudCourses().subscribe((response: CourseRead[]) => {
      this.courses = response;
      this.firstYearCourses = response.filter(x => x.year == "1");
      this.secondYearCourses = response.filter(x => x.year == "2");
      this.thirdYearCourses = response.filter(x => x.year == "3");
      this.hasCourses1 = this.firstYearCourses.length !==0;
      this.hasCourses2 = this.secondYearCourses.length !==0;
      this.hasCourses3 = this.thirdYearCourses.length !==0;
    });
  }

  selectYear(year: string) {
    this.firstYear = year === "1";
    this.scondYear = year === "2";
    this.thirdYear = year === "3";
  }
}
