import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { FileModel } from '../models/file';


@Injectable({
    providedIn: 'root'
})
export class AlertService {

    constructor(private baseService: BaseService) { }


    getAlert(userCode:string) {
        return this.baseService.get(`alerts/${userCode}`);
    }

}
