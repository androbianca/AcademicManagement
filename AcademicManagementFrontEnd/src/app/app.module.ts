import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HomePageComponent } from './pages/home-page/home-page.component';
import { SideBarComponent } from './components/shared/side-bar/side-bar.component';
import { TopBarComponent } from './components/shared/top-bar/top-bar.component';
import { HomeModule } from './pages/home-page/home.modules';
import { GradesModule } from './pages/grades/grades.module';


@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    SideBarComponent,
    TopBarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    HomeModule,
    GradesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
