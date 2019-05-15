import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class NotificationService {

    constructor(private baseService: BaseService) {}

     public add(notification){
        return this.baseService.post<Notification>('notifications',notification);
     }

     public get(){
        return this.baseService.get<Notification[]>(`notify`);
     }

}
 