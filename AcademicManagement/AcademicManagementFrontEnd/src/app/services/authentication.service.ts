import { Injectable } from '@angular/core';
import { Observable, } from 'rxjs';
import { BaseService } from './base-service.service';
import { User } from '../models/user';
import { Login } from '../models/login';
import { CurrentUserDetailsService } from './current-user-details.service';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {

    constructor(private baseService: BaseService, private currentUser:CurrentUserDetailsService) {
     }

    public authenticate(data: Login): Observable<Login> {
        return this.baseService.post2( 'users/login', data );
    }

    public register(data: User): Observable<User> {
        return this.baseService.post2( 'users/register', data );
    }


}
