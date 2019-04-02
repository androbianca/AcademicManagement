import { Component, OnInit } from "@angular/core";
import { CourseService } from "src/app/services/course-service.service";
import { Course } from "src/app/models/course";

@Component({
  selector: "app-grades",
  templateUrl: "./grades.component.html",
  styleUrls: ["./grades.component.scss"]
})
export class GradesComponent {
  courses: Course[];
  firstYearCourses: Course[];
  secondYearCourses: Course[];
  thirdYearCourses: Course[];
  firstYear = true;
  scondYear = false;
  thirdYear = false;
  constructor(private courseService: CourseService) {
    this.getCourses();
  }

  getCourses() {
    this.courseService.getAllByYear().subscribe((response: Course[]) => {
      this.firstYearCourses = response.filter(x => x.year == "1");
      this.secondYearCourses = response.filter(x => x.year == "2");
      this.thirdYearCourses = response.filter(x => x.year == "3");
    });
  }

  selectYear(year: string) {
    this.firstYear = year === "1";
    this.scondYear = year === "2";
    this.thirdYear = year === "3";
  }
}
