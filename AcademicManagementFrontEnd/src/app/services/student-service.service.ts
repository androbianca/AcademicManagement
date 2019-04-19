import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { Course } from '../models/course';
import { CurrentUserDetailsService } from './current-user-details.service';
import { UserDetails } from '../models/userDetails';

@Injectable({
    providedIn: 'root'
})
export class StudentService {

    constructor(private baseService: BaseService) {  }

    public getStudentsByProf(id) {
        return this.baseService.get<Course[]>(`courses/${id}`);
    }

}
