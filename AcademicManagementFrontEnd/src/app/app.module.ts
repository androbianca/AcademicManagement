import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HomePageComponent } from './pages/home-page/home-page.component';
import { SideBarComponent } from './components/shared/side-bar/side-bar.component';
import { TopBarComponent } from './components/shared/top-bar/top-bar.component';
import { PagesModule } from './pages/pages.module';

@NgModule({
  declarations: [
    AppComponent,
    SideBarComponent,
    TopBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    PagesModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
