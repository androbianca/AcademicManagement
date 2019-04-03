import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { Course } from '../models/course';
import { CurrentUserDetailsService } from './current-user-details.service';
import { UserDetails } from '../models/userDetails';

@Injectable({
    providedIn: 'root'
})
export class CourseService {

    public user: UserDetails;
    constructor(private baseService: BaseService,
        private currentUserDetailsService: CurrentUserDetailsService) {
        this.user = this.currentUserDetailsService.getUser();

    }

    public getAll() {
        return this.baseService.get<Course[]>('course');
    }

    public getAllByYear() {
        return this.baseService.get<Course[]>(`courses/current`);
    }
}
