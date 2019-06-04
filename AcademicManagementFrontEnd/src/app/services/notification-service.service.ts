import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { Notif } from '../models/notification';

@Injectable({
    providedIn: 'root'
})

export class NotificationService {

    constructor(private baseService: BaseService) {}

     public add(notification){
        return this.baseService.post<Notif>('notifications',notification);
     }

     public get(){
        return this.baseService.get<Notif[]>(`notify`);
     }

     public read(notification){
      return this.baseService.post<Notif>('notify/update',notification);
   }

}
 