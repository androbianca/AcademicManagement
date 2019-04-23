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
        return this.baseService.post<Grade>('grade',grade);
     }
}
 