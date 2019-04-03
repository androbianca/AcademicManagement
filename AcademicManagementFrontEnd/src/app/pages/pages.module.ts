import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { YearGroupedCoursesCardComponent } from "src/app/components/public/year-grouped-courses-card/year-grouped-courses-card.component";
import { CardHeaderComponent } from "src/app/components/public/card-header/card-header.component";
import { GradesComponent } from './grades/grades.component';
import { LoginComponent } from "src/app/components/public/login/login.component";
import { SignupComponent } from "src/app/components/public/signup/signup.component";
import { ReactiveFormsModule } from '@angular/forms';
import { CoursesComponent } from './courses/courses.component';
import { HomePageComponent } from './home-page/home-page.component';
import { CourseCardComponent } from '../components/public/course-card/course-card.component';
import { CourseGradesComponent } from './course-grades/course-grades.component';

@NgModule({
  imports: [CommonModule,ReactiveFormsModule],
  declarations: [
    GradesComponent,
    CoursesComponent,
    HomePageComponent,
    CourseGradesComponent,
    YearGroupedCoursesCardComponent,
    CardHeaderComponent,
    CourseCardComponent,
    YearGroupedCoursesCardComponent,
    LoginComponent,SignupComponent, CourseGradesComponent
  ],
  exports: [
    GradesComponent,
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
