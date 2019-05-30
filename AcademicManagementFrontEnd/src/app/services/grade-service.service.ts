import { BaseService } from './base-service.service';
import { CurrentUserDetailsService } from './current-user-details.service';
import { Injectable } from '@angular/core';
import { Grade } from '../models/grade';


@Injectable({
    providedIn: 'root'
})
export class GradeService {

    constructor(private baseService: BaseService) {
     }

     public addGrade(grade:Grade){
        return this.baseService.post<Grade>('grades',grade);
     }

     public getFinal(courseId,studentId){
        return this.baseService.get<number>(`grades/${courseId}/${studentId}/final`);
    }

     public getGrades(courseId,studentId){
        return this.baseService.get<Grade[]>(`grades/${courseId}/${studentId}`);
    }
}
 