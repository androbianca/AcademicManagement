import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { PotentialUser } from '../models/potential-user';

@Injectable({
    providedIn: 'root'
})

export class PotentialUserService {

    constructor(private baseService: BaseService) {}

     public addPotentialUser (potentialUser:PotentialUser){
        return this.baseService.post('potentialusers',potentialUser);
     }

     public remove (potentialUserId: string){
        return this.baseService.delete(`potentialusers/${potentialUserId}`);
     }

     public getByUserCode (userCode: string){
      return this.baseService.get<PotentialUser>(`potentialusers/${userCode}`);
   }


}
 