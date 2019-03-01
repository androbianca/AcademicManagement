import { Injectable } from '@angular/core';
import { Observable, } from 'rxjs';
import { BaseService } from './base-service.service';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {

    constructor(private baseService: BaseService) { }

    public authenticate<Login>(data: Login): Observable<Login> {
        let url = "login";
        return this.baseService.post( url, data );
    }

    public register<Register>(data: Register): Observable<Register> {
        let url = "register";
        return this.baseService.post( url, data );
    }


}
