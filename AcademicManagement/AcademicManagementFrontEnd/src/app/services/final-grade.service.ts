import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { FinalGrade } from '../models/final-grade';

@Injectable({
    providedIn: 'root'
})
export class FinalGradeService {

    constructor(private baseService: BaseService) {
    }

    public getAllByCourse(courseId) {
        return this.baseService.get<FinalGrade[]>(`finalgrades/${courseId}`);
    }

}
