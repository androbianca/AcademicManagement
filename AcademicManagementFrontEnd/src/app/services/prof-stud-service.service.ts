import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { ProfStud } from '../models/prof-studs';

@Injectable({
    providedIn: 'root'
})

export class ProfStudService {

    constructor(private baseService: BaseService) { }

    public addProfStuds(profStud: ProfStud[]) {
        return this.baseService.post<ProfStud[]>('profstuds', profStud);
    }

    public delete(profStudId: string) {
        return this.baseService.delete(`profstuds/${profStudId}`);
    }

    public getByProfId(profId: string) {
        return this.baseService.get<ProfStud[]>(`profstuds/${profId}`);
    }

}
