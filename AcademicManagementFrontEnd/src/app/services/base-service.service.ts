import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  public enviroment = 'https://localhost:44304/api/';
  constructor(private http: HttpClient) { }

  public post<T>(url: string, data: T): Observable<T> {
    const authToken = localStorage.getItem('jwt');

    const completeUrl: string = this.enviroment + url;
    return this.http.post<T>(completeUrl, data,  { headers: new HttpHeaders({'Content-Type': 'application/json',
    Authorization: authToken})})
  }

  public put<T>(url: string, data: T): Observable<T> {
    const authToken = localStorage.getItem('jwt');
    const completeUrl: string = this.enviroment + url;
    return this.http.post<T>(completeUrl, data,  { headers: new HttpHeaders({'Content-Type': 'application/json',
    Authorization: authToken})})
  }


  public get<T>(url: string): Observable<T> {
    const authToken = localStorage.getItem('jwt');
    const completeUrl: string = this.enviroment + url;
    return this.http.get<T>(completeUrl, { headers: {'Content-Type': 'application/json',
    Authorization: authToken}});
  }

  public delete<T>(url: string): Observable<T> {
    const authToken = localStorage.getItem('jwt');
    const completeUrl: string = this.enviroment + url;
    return this.http.delete<T>(completeUrl, { headers: {'Content-Type': 'application/json',
    Authorization: authToken}});
  }

  public post2<T>(url: string, data: T): Observable<T> {
    const completeUrl: string = this.enviroment + url;
    return this.http.post<T>(completeUrl, data);
  }

  public postFile<T>(url: string, data: T): Observable<T> {
    const authToken = localStorage.getItem('jwt');

    const completeUrl: string = this.enviroment + url;
    return this.http.post<T>(completeUrl, data,  { headers: new HttpHeaders({
    Authorization: authToken})})
  }

}
