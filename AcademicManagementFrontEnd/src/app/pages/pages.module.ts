import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { YearGroupedCoursesCardComponent } from "src/app/components/public/others/year-grouped-courses-card/year-grouped-courses-card.component";
import { LoginComponent } from "src/app/components/public/authentication/login/login.component";
import { SignupComponent } from "src/app/components/public/authentication/signup/signup.component";
import { ReactiveFormsModule } from '@angular/forms';
import { HomePageComponent } from './home-page/home-page.component';
import { CourseCardComponent } from '../components/public/others/course-card/course-card.component';
import { CourseGradesComponent } from './course-grades/course-grades.component';
import { ProfGradesComponent } from './prof-grades/prof-grades.component';
import { StudGradesComponent } from './stud-grades/stud-grades.component';
import { StudentCardComponent } from '../components/public/others/student-card/student-card.component';
import { AddGradeComponent } from '../components/public/grades/add-grade/add-grade.component';
import { GradeCardComponent } from '../components/public/grades/grade-card/grade-card.component';
import { GradesCardComponent } from '../components/public/grades/grades-card/grades-card.component';
import { MAT_DIALOG_DEFAULT_OPTIONS, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { AddGradeModalContentComponent } from '../components/public/grades/add-grade-modal-content/add-grade-modal-content.component';
import { ProfessorsComponent } from './professors/professors.component';
import { ProfCardComponent } from '../components/public/others/prof-card/prof-card.component';
import { ManageCoursesComponent } from './manage-courses/manage-courses.component';
import { AddCoursesComponent } from '../components/public/management/course/add-courses/add-courses.component';
import { ManageProfessorsComponent } from './manage-professors/manage-professors.component';
import { MatSelectModule } from '@angular/material/select';
import { ErrorStateMatcher, ShowOnDirtyErrorStateMatcher, MatNativeDateModule } from '@angular/material/core';
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
import { DisplayFeedbackComponent } from '../components/public/feedback/display-feedback/display-feedback.component';
import { NotificationPanelComponent } from '../components/public/notifications/notification-panel/notification-panel.component';
import { NotificationCardComponent } from '../components/public/notifications/notification-card/notification-card.component';
import { AddFeedbackComponent } from '../components/public/feedback/add-feedback/add-feedback.component';
import { NewsfeedPageComponent } from './newsfeed-page/newsfeed-page.component';
import { FeedCardComponent } from '../components/public/feed/feed-card/feed-card.component';
import { MatSnackBarModule, MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';
import { FileUploadComponent } from '../components/public/files/file-upload/file-upload.component';
import { FileDownloadComponent } from '../components/public/files/file-download/file-download.component';
import { ChartModule, HIGHCHARTS_MODULES } from 'angular-highcharts';
import { BellCurveChartComponent } from '../components/public/others/bell-curve-chart/bell-curve-chart.component';
import exporting from 'highcharts/modules/exporting.src';
import windbarb from 'highcharts/modules/windbarb.src';
import { GradeCategoryComponent } from '../components/public/grade-categories/grade-category/grade-category.component';
import { GradeCategoryModalComponentComponent } from '../components/public/grade-categories/grade-category-modal-component/grade-category-modal-component.component';
import { ResourcesComponent } from './resources/resources.component';
import { BellCurvePageComponent } from './bell-curve-page/bell-curve-page.component';
import { NoResultsComponent } from '../components/public/others/no-results/no-results.component';
import { UpdateCourseComponent } from '../components/public/management/course/update-course/update-course.component';
import { EditGradeComponent } from '../components/public/grades/edit-grade/edit-grade.component';
import { CommentCardComponent } from '../components/public/feed/leave-comment-card/comment-card.component';
import { DisplayCommentCardComponent } from '../components/public/feed/display-comment-card/display-comment-card.component';
import { OptionalService } from '../services/optional.service';
import { OptionalsPageComponent } from './optionals-page/optionals-page.component';
import { OptionalsComponent } from '../components/public/others/optionals/optionals.component';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { ChooseOptionalsComponent } from './choose-optionals/choose-optionals.component';
import { CategoriesModalComponent } from '../components/public/grade-categories/categories-modal/categories-modal.component';
import { DisplayCategoriesComponent } from '../components/public/grade-categories/display-categories/display-categories.component';
import { CategoryCardComponent } from '../components/public/grade-categories/category-card/category-card.component';
import { EditCategoryComponent } from '../components/public/grade-categories/edit-category/edit-category.component';
import { AddFeedbackModalContentComponent } from '../components/public/feedback/add-feedback-modal-content/add-feedback-modal-content.component';

export function highchartsModules() {
  return [exporting, windbarb];
}

@NgModule({
  imports: [CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatSelectModule,
    MatSnackBarModule,
    ChartModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
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
    AddFeedbackModalContentComponent,
    NewsfeedPageComponent,
    FeedCardComponent,
    FileUploadComponent,
    FileDownloadComponent,
    BellCurveChartComponent,
    GradeCategoryComponent,
    GradeCategoryModalComponentComponent,
    ResourcesComponent,
    BellCurvePageComponent,
    NoResultsComponent,
    UpdateCourseComponent,
    EditGradeComponent,
    CommentCardComponent,
    DisplayCommentCardComponent,
    OptionalsComponent,
    OptionalsPageComponent,
    ChooseOptionalsComponent,
    CategoriesModalComponent,
    DisplayCategoriesComponent,
    CategoryCardComponent,
    EditCategoryComponent


  ],
  entryComponents: [AddGradeModalContentComponent,
    AddFeedbackModalContentComponent,
    SignupComponent,
    GradeCategoryModalComponentComponent,
    CategoriesModalComponent
  ],
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
    AddFeedbackModalContentComponent,
    FeedCardComponent,
    FileUploadComponent,
    FileDownloadComponent,
    BellCurveChartComponent,
    GradeCategoryComponent,
    GradeCategoryModalComponentComponent,
    NoResultsComponent,
    UpdateCourseComponent,
    EditGradeComponent,
    CommentCardComponent,
    DisplayCommentCardComponent,
    OptionalsComponent,
    OptionalsPageComponent,
    CategoriesModalComponent,
    DisplayCategoriesComponent,
    CategoryCardComponent,
    EditCategoryComponent
  ],

  providers: [MatDatepickerModule,MatNativeDateModule,
    { provide: MatDialogRef, useValue: {} },
    { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { hasBackdrop: true } },
    { provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher },
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2500 } },
    { provide: HIGHCHARTS_MODULES, useFactory: highchartsModules },
    { provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher }

  ]
})

export class PagesModule { }
