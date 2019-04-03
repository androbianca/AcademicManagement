import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { UserDetails } from '../models/userDetails';
import { Subject } from 'rxjs';

const currentEmployeeUrl = 'user/current';

@Injectable({
  providedIn: 'root'
})

export class CurrentUserDetailsService {
  private user: UserDetails;
  private user$ = new Subject();
  constructor(private service: BaseService) { }

  setCurrentUser(user) {
    this.user = user;
    this.user$.next(user);
  }

  isCurrentUserSet() {
    return !!this.user;
  }

  getUser() {
    return this.user;
  }

  getUserObservable() {
    return this.user$.asObservable();
  }

  getCurrentUserService() {
    return this.service.get(currentEmployeeUrl);
  }
}
