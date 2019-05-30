import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { GradeCategory } from '../models/grade-category';


@Injectable({
    providedIn: 'root'
})
export class GradeCategoryService {

    constructor(private baseService: BaseService) {
    }

    public addGradeCategory(gradeCategory: GradeCategory) {
        return this.baseService.post<GradeCategory>('gradecategories', gradeCategory);
    }

    public getByCourseId(courseId) {
        return this.baseService.get<GradeCategory[]>(`gradecategories/${courseId}`);
    }

}
