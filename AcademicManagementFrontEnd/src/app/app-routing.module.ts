import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { UserGuard } from './guards/user.guard';
import { GradesComponent } from './pages/grades/grades.component';

const routes: Routes = [
  {
    path: '',
    component: HomePageComponent,
  },
  {
    path: 'profile',
    component: GradesComponent,
    canActivate: [UserGuard]
  },
  {
    path: 'grades',
    component: GradesComponent,
    canActivate: [UserGuard]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
