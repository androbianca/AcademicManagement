import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { GroupRead } from '../models/groupRead';
import { GroupWrite } from '../models/groupWrite';

@Injectable({
    providedIn: 'root'
})

export class GroupService {

    constructor(private baseService: BaseService) {}

     public getAll (){
        return this.baseService.get<GroupRead[]>('groups');
     }

     public addGroup(group:GroupWrite){
        return this.baseService.post<GroupWrite>('groups',group);
     }

     public removeGroup(groupId:string){
      return this.baseService.delete(`groups/${groupId}`);
   }
}
 