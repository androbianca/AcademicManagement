import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { UserDetails } from '../models/userDetails';
import { CourseFormula } from '../models/course-formula';

@Injectable({
    providedIn: 'root'
})
export class CoureFormulaService {

    constructor(private baseService: BaseService) {
    }

    public add(courseFormula: CourseFormula) {
        return this.baseService.post<CourseFormula>('formulas', courseFormula);
    }

    public getByCourseId(id: string) {
        return this.baseService.get<CourseFormula>(`formulas/${id}`);
    }

}
