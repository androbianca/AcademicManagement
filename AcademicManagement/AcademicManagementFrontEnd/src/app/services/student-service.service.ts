import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { Student } from '../models/student';

@Injectable({
    providedIn: 'root'
})
export class StudentService {

    constructor(private baseService: BaseService) {  }

    public getStudentsByProf(id) {
        return this.baseService.get<Student[]>(`students/course/${id}`);
    }

    public addStudent(student) {
        return this.baseService.post<Student>(`students`,student);
    }

    public update(student) {
        return this.baseService.post<Student>(`students/edit`,student);
    }

    public removeStudent(studentId) {
        return this.baseService.delete(`students/${studentId}`);
    }

    public getAll() {
        return this.baseService.get<Student[]>(`students`);
    }

    public getById(usercode:string) {
        return this.baseService.get<Student>(`students/${usercode}`);
    }

}
