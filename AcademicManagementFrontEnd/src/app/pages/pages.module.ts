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
import { StudentCardComponent } from '../components/public/student-card/student-card.component';
import { AddGradeComponent } from '../components/public/add-grade/add-grade.component';
import { GradeCardComponent } from '../components/public/grade-card/grade-card.component';
import { GradesCardComponent } from '../components/public/grades-card/grades-card.component';
import { MAT_DIALOG_DEFAULT_OPTIONS, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { AddGradeModalContentComponent } from '../components/public/add-grade-modal-content/add-grade-modal-content.component';
import { ManageCoursesComponent } from './manage-courses/manage-courses.component';
import { AddCoursesComponent } from '../components/public/add-courses/add-courses.component';
import { ManageProfessorsComponent } from './manage-professors/manage-professors.component';
import { AddProfComponent } from '../components/public/add-prof/add-prof.component';
import {MatSelectModule} from '@angular/material/select';
import { ErrorStateMatcher, ShowOnDirtyErrorStateMatcher } from '@angular/material/core';

@NgModule({
  imports: [CommonModule,ReactiveFormsModule,MatDialogModule,MatSelectModule],
  declarations: [
    StudGradesComponent,
    CoursesComponent,
    HomePageComponent,
    CourseGradesComponent,
    YearGroupedCoursesCardComponent,
    CardHeaderComponent,
    CourseCardComponent,
    YearGroupedCoursesCardComponent,
    LoginComponent,SignupComponent, CourseGradesComponent, ProfGradesComponent,
    StudentCardComponent,
    AddGradeComponent,GradeCardComponent,GradesCardComponent,AddGradeModalContentComponent, ManageCoursesComponent,AddCoursesComponent, ManageProfessorsComponent,AddProfComponent
  ],
  entryComponents : [AddGradeModalContentComponent],
  exports: [
    StudGradesComponent,
    CoursesComponent,
    HomePageComponent,
    CourseGradesComponent,
    YearGroupedCoursesCardComponent,
    CardHeaderComponent,
    CourseCardComponent,
    YearGroupedCoursesCardComponent,
    LoginComponent,SignupComponent,StudentCardComponent,
    AddGradeComponent,GradeCardComponent,GradesCardComponent,AddGradeModalContentComponent,AddCoursesComponent,AddProfComponent
  ],
  providers: [
    { provide: MatDialogRef, useValue: {} },
    {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false}} ,
    { provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher}
  ]

})
export class PagesModule {}
