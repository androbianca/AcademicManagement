import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SideBarComponent } from './components/shared/side-bar/side-bar.component';
import { TopBarComponent } from './components/shared/top-bar/top-bar.component';
import { PagesModule } from './pages/pages.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OverlayModule } from '@angular/cdk/overlay';
import { AlertModalComponent } from './components/public/others/alert-modal/alert-modal.component';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';
import { SeeGradesComponent } from './components/public/grades/see-grades/see-grades.component';
import { AllGradesCardComponent } from './components/public/grades/all-grades-card/all-grades-card.component';

@NgModule({
  declarations: [
    AppComponent,
    SideBarComponent,
    TopBarComponent,
    AlertModalComponent,
    SeeGradesComponent,
    AllGradesCardComponent,
  ],
  exports: [AlertModalComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    PagesModule,
    BrowserAnimationsModule,
    OverlayModule,
    MatDialogModule
  ],

  entryComponents: [AlertModalComponent],
  bootstrap: [AppComponent],
  providers: [
    { provide: MatDialogRef, useValue: {} },
    { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { hasBackdrop: true } },
  ]
})
export class AppModule { }
