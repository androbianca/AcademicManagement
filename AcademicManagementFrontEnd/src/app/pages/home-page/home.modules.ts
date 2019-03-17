import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { LoginComponent } from "src/app/components/public/login/login.component";
import { SignupComponent } from "src/app/components/public/signup/signup.component";
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [CommonModule,ReactiveFormsModule],
    declarations: [LoginComponent, SignupComponent],
    exports: [LoginComponent, SignupComponent]
})
export class HomeModule { }
