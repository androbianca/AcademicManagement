import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { CurrentUserDetailsService } from '../services/current-user-details.service';
import { UserDetails } from '../models/userDetails';

@Injectable({
  providedIn: 'root'
})
export class UserGuard implements CanActivate {
  user : UserDetails;

  constructor(
    private currentUserDetailsService: CurrentUserDetailsService
  ) { }

  canActivate(): Promise<boolean> {

    return new Promise((resolve, reject) => {
      if (this.currentUserDetailsService.isCurrentUserSet()) {
        resolve(true);
      } else {
        this.currentUserDetailsService.getCurrentUserService().subscribe(
          (data: UserDetails) => {
            this.user = data;
            this.currentUserDetailsService.setCurrentUser(this.user);
            resolve(true);
          },
          error => {
            reject();
          }
        );
      }
    });
  }
}
