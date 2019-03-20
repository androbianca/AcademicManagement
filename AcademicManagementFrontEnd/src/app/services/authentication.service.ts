import { Injectable } from '@angular/core';
import { Observable, } from 'rxjs';
import { BaseService } from './base-service.service';
import { User } from '../models/user';
import { Login } from '../models/login';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {

    constructor(private baseService: BaseService) { }

    public authenticate(data: Login): Observable<Login> {
        return this.baseService.post( 'login', data );
    }

    public register(data: User): Observable<User> {
        return this.baseService.post( 'register', data );
    }


}
