import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { YearGroupedCoursesCardComponent } from "src/app/components/public/year-grouped-courses-card/year-grouped-courses-card.component";
import { CardHeaderComponent } from "src/app/components/public/card-header/card-header.component";
import { LoginComponent } from "src/app/components/public/login/login.component";
import { SignupComponent } from "src/app/components/public/signup/signup.component";
import { ReactiveFormsModule } from '@angular/forms';
import { CoursesComponent } from './courses/courses.component';
import { HomePageComponent } from './home-page/home-page.component';
import { CourseCardComponent } from '../components/public/course-card/course-card.component';
import { CourseGradesComponent } from './course-grades/course-grades.component';
import { ProfGradesComponent } from './prof-grades/prof-grades.component';
import { StudGradesComponent } from './stud-grades/stud-grades.component';

@NgModule({
  imports: [CommonModule,ReactiveFormsModule],
  declarations: [
    StudGradesComponent,
    CoursesComponent,
    HomePageComponent,
    CourseGradesComponent,
    YearGroupedCoursesCardComponent,
    CardHeaderComponent,
    CourseCardComponent,
    YearGroupedCoursesCardComponent,
    LoginComponent,SignupComponent, CourseGradesComponent, ProfGradesComponent
  ],
  exports: [
    StudGradesComponent,
    CoursesComponent,
    HomePageComponent,
    CourseGradesComponent,
    YearGroupedCoursesCardComponent,
    CardHeaderComponent,
    CourseCardComponent,
    YearGroupedCoursesCardComponent,
    LoginComponent,SignupComponent
  ]
})
export class PagesModule {}
