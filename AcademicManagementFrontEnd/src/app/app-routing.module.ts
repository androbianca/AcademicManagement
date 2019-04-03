import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { UserGuard } from './guards/user.guard';
import { GradesComponent } from './pages/grades/grades.component';
import { CoursesComponent } from './pages/courses/courses.component';
import { CourseGradesComponent } from './pages/course-grades/course-grades.component';

const routes: Routes = [
  {
    path: '',
    component: HomePageComponent,
  },
  {
    path: 'grades',
    component: GradesComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'courses',
    component: CoursesComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'grades/course',
    component: CourseGradesComponent,
    canActivate: [UserGuard]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
