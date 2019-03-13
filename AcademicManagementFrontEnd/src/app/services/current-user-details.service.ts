import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { UserDetails } from '../models/userDetails';

const currentEmployeeUrl: string = "user/current";

@Injectable({
  providedIn: 'root'
})

export class CurrentUserDetailsService {
  private user = new UserDetails();
  private user$ = new Subject();
  private headers = new Headers();
  constructor(private service: BaseService) { }

  setCurrentUser(user) {
    this.user = user;
   // this.user$.next(user);
  }

  isCurrentUserSet() {
    return !!this.user;
  }

  getUser() : UserDetails{
    return this.user;
  }

  getUserObservable() {
    return this.user$.asObservable();
  }

 getCurrentUserService() {
    let authToken = localStorage.getItem('jwt');
    return this.service.get(currentEmployeeUrl, { headers: {'Content-Type': 'application/json',
     'Authorization': authToken}});
  }
}
