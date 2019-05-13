import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { Student } from '../models/student';

@Injectable({
    providedIn: 'root'
})
export class StudentService {

    constructor(private baseService: BaseService) {  }

    public getStudentsByProf(id) {
        return this.baseService.get<Student[]>(`students/${id}`);
    }

    public addStudent(student) {
        return this.baseService.post<Student>(`students`,student);
    }

}
