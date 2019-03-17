import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { GradesComponent } from './grades.component';


@NgModule({
    imports: [
        CommonModule,
    ],
    declarations: [GradesComponent],
    exports: [GradesComponent]
})

export class GradesModule {
}
