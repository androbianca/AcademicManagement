import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class PotentialUserService {

    constructor(private baseService: BaseService) {}

     public addPotentialUser (userCode){
        console.log(userCode)
        return this.baseService.post('potentialusers',userCode);
     }

     public remove (potentialUserId: string){
        return this.baseService.delete(`potentialusers/${potentialUserId}`);
     }

}
 