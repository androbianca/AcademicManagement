import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { YearGroupedCoursesCardComponent } from "src/app/components/public/year-grouped-courses-card/year-grouped-courses-card.component";
import { LoginComponent } from "src/app/components/public/login/login.component";
import { SignupComponent } from "src/app/components/public/signup/signup.component";
import { ReactiveFormsModule } from '@angular/forms';
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
import { ProfessorsComponent } from './professors/professors.component';
import { ProfCardComponent } from '../components/public/prof-card/prof-card.component';
import { ManageCoursesComponent } from './manage-courses/manage-courses.component';
import { AddCoursesComponent } from '../components/public/management/course/add-courses/add-courses.component';
import { ManageProfessorsComponent } from './manage-professors/manage-professors.component';
import { MatSelectModule } from '@angular/material/select';
import { ErrorStateMatcher, ShowOnDirtyErrorStateMatcher } from '@angular/material/core';
import { ProfCoursesComponent } from './prof-courses/prof-courses.component';
import { StudentCoursesComponent } from './student-courses/student-courses.component';
import { AddStudComponent } from '../components/public/management/student/add-stud/add-stud.component';
import { ManageGroupsComponent } from './manage-groups/manage-groups.component';
import { AddGroupComponent } from '../components/public/management/group/add-group/add-group.component';
import { ManageStudComponent } from './manage-studs/manage-stud.component';
import { AddProfComponent } from '../components/public/management/professor/add-prof/add-prof.component';
import { RemoveCourseComponent } from '../components/public/management/course/remove-course/remove-course.component';
import { RemoveProfComponent } from '../components/public/management/professor/remove-prof/remove-prof.component';
import { RemoveStudentComponent } from '../components/public/management/student/remove-student/remove-student.component';
import { RemoveGroupComponent } from '../components/public/management/group/remove-group/remove-group.component';
import { AddProfCoursesComponent } from '../components/public/management/professor/add-prof-courses/add-prof-courses.component';
import { AddOptionalCoursesComponent } from '../components/public/management/student/add-optional-courses/add-optional-courses.component';
import { CourseProfileComponent } from './course-profile/course-profile.component';
import { ProfProfileComponent } from './prof-profile/prof-profile.component';
import { DisplayFeedbackComponent } from '../components/public/display-feedback/display-feedback.component';
import { NotificationPanelComponent } from '../components/public/notification-panel/notification-panel.component';
import { OverlayModule } from '@angular/cdk/overlay';
import { NotificationCardComponent } from '../components/public/notification-card/notification-card.component';
import { AddFeedbackComponent } from '../components/public/add-feedback/add-feedback.component';
import { AddFeedbackModalContentComponent } from '../components/public/add-feedback-modal-content/add-feedback-modal-content.component';



@NgModule({
  imports: [CommonModule, ReactiveFormsModule, MatDialogModule, MatSelectModule],
  declarations: [
    StudGradesComponent,
    StudentCoursesComponent,
    HomePageComponent,
    CourseCardComponent,
    YearGroupedCoursesCardComponent,
    LoginComponent, 
    SignupComponent,
    CourseGradesComponent,
    ProfGradesComponent,
    StudentCardComponent,
    AddGradeComponent,
    ProfessorsComponent,
    ProfCardComponent, 
    GradeCardComponent, 
    GradesCardComponent, 
    AddGradeModalContentComponent, 
    ManageCoursesComponent, 
    AddCoursesComponent, 
    ManageProfessorsComponent, 
    AddProfComponent,
    ProfCoursesComponent,
    ManageStudComponent,
    AddStudComponent,
    ManageGroupsComponent,
    AddGroupComponent,
    RemoveCourseComponent,
    RemoveProfComponent,
    RemoveStudentComponent,
    RemoveGroupComponent,
    AddProfCoursesComponent,
    AddOptionalCoursesComponent,
    CourseProfileComponent,
    ProfProfileComponent,
    DisplayFeedbackComponent,
    NotificationPanelComponent,
    NotificationCardComponent,
    AddFeedbackComponent,
    AddFeedbackModalContentComponent
  ],
  entryComponents: [AddGradeModalContentComponent,AddFeedbackModalContentComponent],
  exports: [
    StudGradesComponent,
    StudentCoursesComponent,
    HomePageComponent,
    CourseGradesComponent,
    CourseCardComponent,
    YearGroupedCoursesCardComponent,
    LoginComponent,
    SignupComponent,
    StudentCardComponent,
    AddGradeComponent,
    ProfCardComponent, 
    GradeCardComponent, 
    GradesCardComponent, 
    AddGradeModalContentComponent, 
    AddCoursesComponent, 
    AddProfComponent,
    AddStudComponent,
    AddGroupComponent,
    RemoveCourseComponent,
    RemoveProfComponent,
    RemoveStudentComponent,
    RemoveGroupComponent,
    AddProfCoursesComponent,
    AddOptionalCoursesComponent,
    DisplayFeedbackComponent,
    NotificationPanelComponent,
    NotificationCardComponent,
    AddFeedbackComponent,
    AddFeedbackModalContentComponent

  ],
  providers: [
    { provide: MatDialogRef, useValue: {} },
    { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { hasBackdrop: true } },
    { provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher }
  ]

})
export class PagesModule { }
