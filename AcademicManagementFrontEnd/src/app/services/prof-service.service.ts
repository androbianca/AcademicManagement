import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { Professor } from '../models/professor';
import { ProfStuds } from '../models/prof-studs';


@Injectable({
    providedIn: 'root'
})
export class ProfService {

    constructor(private baseService: BaseService) {
     }

     public addProf(prof:Professor){
        return this.baseService.post<Professor>('prof',prof);
     }

     public addProfStuds(profStuds:ProfStuds){
        return this.baseService.post<ProfStuds>('prof',profStuds);
     }

}
 