import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { Group } from '../models/group';

@Injectable({
    providedIn: 'root'
})

export class GroupService {

    constructor(private baseService: BaseService) {}

     public getAll (){
        return this.baseService.get<Group[]>('group');
     }

}
 