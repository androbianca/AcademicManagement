import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { ProfStud } from '../models/prof-studs';

@Injectable({
    providedIn: 'root'
})

export class ProfStudService {

    constructor(private baseService: BaseService) {}

     public addProfStuds (profStud:ProfStud[]){
        return this.baseService.post<ProfStud[]>('profStud', profStud);
     }

}
 