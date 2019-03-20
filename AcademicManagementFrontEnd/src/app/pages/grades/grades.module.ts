import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { GradesComponent } from './grades.component';
import { CourseCardComponent } from 'src/app/components/public/course-card/course-card.component';
import { CoursesCardComponent } from 'src/app/components/public/courses-card/courses-card.component';
import { YearGroupedCoursesCardComponent } from 'src/app/components/public/year-grouped-courses-card/year-grouped-courses-card.component';
import { CardHeaderComponent } from 'src/app/components/public/card-header/card-header.component';


@NgModule({
    imports: [
        CommonModule,
    ],
    declarations: [GradesComponent, CourseCardComponent, CoursesCardComponent, YearGroupedCoursesCardComponent, CardHeaderComponent, YearGroupedCoursesCardComponent


    ],
    exports: [GradesComponent, CourseCardComponent, CoursesCardComponent, YearGroupedCoursesCardComponent, CardHeaderComponent, YearGroupedCoursesCardComponent


    ]
})

export class GradesModule {
}
