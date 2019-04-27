import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { UserGuard } from './guards/user.guard';
import { CoursesComponent } from './pages/courses/courses.component';
import { CourseGradesComponent } from './pages/course-grades/course-grades.component';
import { StudGradesComponent } from './pages/stud-grades/stud-grades.component';
import { ProfGradesComponent } from './pages/prof-grades/prof-grades.component';

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
    path: 'courses',
    component: CoursesComponent,
    canActivate: [UserGuard]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
