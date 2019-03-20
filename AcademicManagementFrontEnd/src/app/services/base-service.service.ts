import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  public enviroment = 'https://localhost:44304/api/';
  public authToken = localStorage.getItem('jwt');
  constructor(private http: HttpClient) { }

  public post<T>(url: string, data: T): Observable<T> {
    const completeUrl: string = this.enviroment + url;
    return this.http.post<T>(completeUrl, data,  { headers: {'Content-Type': 'application/json',
    Authorization: this.authToken}});
  }

  public get<T>(url: string): Observable<T> {
    const completeUrl: string = this.enviroment + url;
    return this.http.get<T>(completeUrl, { headers: {'Content-Type': 'application/json',
    Authorization: this.authToken}});
  }
}
