import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { StudCourse } from '../models/stud-course';

@Injectable({
    providedIn: 'root'
})

export class StudCourseService {

    constructor(private baseService: BaseService) { }

    public addStudCourses(studCourse: StudCourse[]) {
        return this.baseService.post<StudCourse[]>('studcourses', studCourse);
    }

    public delete(studCourseId: string) {
        return this.baseService.delete<StudCourse>(`studcourses/${studCourseId}`);
    }

    public getByStudentId(studId: string) {
        return this.baseService.get<StudCourse[]>(`studcourses/${studId}`);
    }
}