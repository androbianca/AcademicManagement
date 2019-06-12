import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { UserRole } from '../models/user-role';

@Injectable({
    providedIn: 'root'
})
export class UserRoleService {

    constructor(private baseService: BaseService) {  }

    public getStudentRoleId() {
        return this.baseService.get<UserRole>(`userroles/student`);
    }

    public getProfRoleId() {
        return this.baseService.get<UserRole>(`userroles/professor`);
    }

    public getById(id:string) {
        return this.baseService.get<UserRole>(`userroles/${id}`);
    }


}
