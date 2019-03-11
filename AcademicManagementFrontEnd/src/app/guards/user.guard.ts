import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';

import { CurrentUserDetailsService } from '../services/current-user-details.service';
import { User } from '../models/user';

@Injectable({
    providedIn: 'root'
})
export class UserGuard implements CanActivate {
    user: User;

    constructor(
        private currentUserDetailsService : CurrentUserDetailsService
    ) { }

    canActivate(): Promise<boolean> {
        
        return new Promise((resolve, reject) => {
            if (this.currentUserDetailsService.isCurrentUserSet()) {
                resolve(true);
            } else {
                this.currentUserDetailsService.getCurrentUserService().subscribe(
                    data => {
                        this.currentUserDetailsService.setCurrentUser(data);
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
