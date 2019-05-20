import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { Professor } from '../models/professor';

@Injectable({
   providedIn: 'root'
})
export class ProfService {

   constructor(private baseService: BaseService) {
   }

   public getAll() {
      return this.baseService.get<Professor[]>('profs');
   }

   public getById(userCode: string) {
      return this.baseService.get<Professor>(`profs/${userCode}`);
   }

   public addProf(prof: Professor) {
      return this.baseService.post<Professor>('profs', prof);
   }

   public remove(profId: string) {
      return this.baseService.delete(`profs/${profId}`);
   }

   public getByCourseId(courseId: string) {
      return this.baseService.get<Professor[]>(`profs/${courseId}`);
   }

}
