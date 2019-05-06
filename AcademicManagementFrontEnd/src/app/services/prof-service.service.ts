import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { Professor } from '../models/professor';


@Injectable({
    providedIn: 'root'
})
export class ProfService {

    constructor(private baseService: BaseService) {
     }

     public addProf(prof:Professor){
        return this.baseService.post<Professor>('prof',prof);
     }

}
 