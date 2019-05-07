import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class PotentialUserService {

    constructor(private baseService: BaseService) {}

     public addPotentialUser (userCode){
        return this.baseService.post<string>('potentialUser',userCode);
     }

}
 