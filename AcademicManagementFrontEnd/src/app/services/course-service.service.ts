import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { CurrentUserDetailsService } from './current-user-details.service';
import { UserDetails } from '../models/userDetails';
import { CourseRead } from '../models/course-read';

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
        return this.baseService.get<CourseRead[]>('courses');
    }

    public getStudCourses() {
        return this.baseService.get<CourseRead[]>(`courses/current/stud`);
    }

    public getProfCourses() {
        return this.baseService.get<CourseRead[]>(`courses/current/prof`);
    }

    public addCourse(course) {
        return this.baseService.post<CourseRead[]>('courses', course);
    }
}
