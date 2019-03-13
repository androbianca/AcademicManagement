import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';

import { CurrentUserDetailsService } from '../services/current-user-details.service';
import { User } from '../models/user';
import { UserDetails } from '../models/userDetails';

@Injectable({
  providedIn: 'root'
})
export class UserGuard implements CanActivate {
  user= new UserDetails();

  constructor(
    private currentUserDetailsService: CurrentUserDetailsService
  ) { }

  canActivate(): Promise<boolean> {

    return new Promise((resolve, reject) => {
      // if (this.currentUserDetailsService.isCurrentUserSet()) {
      //     resolve(true);
      // } else {
      this.currentUserDetailsService.getCurrentUserService().subscribe(
        data => {

          this.user.Email = (<any>data).email;
          this.user.FirstName = (<any>data).firstName;
          this.user.LastName = (<any>data).lastName
          this.user.Group = (<any>data).group;
          this.user.Year = (<any>data).year;
          this.currentUserDetailsService.setCurrentUser(this.user);
          resolve(true);
        },
        error => {
          reject();
        }
      );
      // }
    });
  }
}
