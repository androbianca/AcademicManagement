import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { UserGuard } from './guards/user.guard';
import { CourseGradesComponent } from './pages/course-grades/course-grades.component';
import { StudGradesComponent } from './pages/stud-grades/stud-grades.component';
import { ProfGradesComponent } from './pages/prof-grades/prof-grades.component';
import { ProfessorsComponent } from './pages/professors/professors.component';
import { ManageCoursesComponent } from './pages/manage-courses/manage-courses.component';
import { ManageProfessorsComponent } from './pages/manage-professors/manage-professors.component';
import { ProfCoursesComponent } from './pages/prof-courses/prof-courses.component';
import { StudentCoursesComponent } from './pages/student-courses/student-courses.component';
import { ManageStudComponent } from './pages/manage-studs/manage-stud.component';
import { ManageGroupsComponent } from './pages/manage-groups/manage-groups.component';
import { CourseProfileComponent } from './pages/course-profile/course-profile.component';
import { ProfProfileComponent } from './pages/prof-profile/prof-profile.component';
import { NewsfeedPageComponent } from './pages/newsfeed-page/newsfeed-page.component';
import { ResourcesComponent } from './pages/resources/resources.component';
import { BellCurveChartComponent } from './components/public/others/bell-curve-chart/bell-curve-chart.component';
import { BellCurvePageComponent } from './pages/bell-curve-page/bell-curve-page.component';
import { OptionalsComponent } from './components/public/others/optionals/optionals.component';
import { ChooseOptionalsComponent } from './pages/choose-optionals/choose-optionals.component';
import { SeeGradesComponent } from './components/public/grades/see-grades/see-grades.component';

const routes: Routes = [
  {
    path: '',
    component: HomePageComponent
  },
  {
    path: 'grades',
    component: StudGradesComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'grades/:courseId',
    component: CourseGradesComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'courses/:courseId',
    component: ProfGradesComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'courses/resources/:courseId',
    component: ResourcesComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'courses/grades/:courseId/:profId',
    component: SeeGradesComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'courses/bellcurve/:courseId',
    component:  BellCurvePageComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'profcourses',
    component: ProfCoursesComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'studcourses',
    component: StudentCoursesComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'professors',
    component: ProfessorsComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'manage/courses',
    component: ManageCoursesComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'manage/courses/optionals',
    component: OptionalsComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'optionals',
    component: ChooseOptionalsComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'manage/professors',
    component: ManageProfessorsComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'manage/students',
    component: ManageStudComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'manage/groups',
    component: ManageGroupsComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'studcourses/course/:courseId',
    component: CourseProfileComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'professors/:profId',
    component: ProfProfileComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'newsfeed',
    component: NewsfeedPageComponent,
    canActivate: [UserGuard]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
