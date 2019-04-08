import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { CurrentUserDetailsService } from './services/current-user-details.service';
import { UserDetails } from './models/userDetails';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {

  title = 'AcademicManagementFrontEnd';
  home = false;
  route: string;
  user:UserDetails;
  constructor(private router: Router, private currentUserDetailsService:CurrentUserDetailsService) {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      this.route = this.router.url;
      this.home = this.route === '/' ? true : false;
    });
    this.currentUserDetailsService.getUserObservable().subscribe(result => {
      this.user = result;
   });
  }
  ngOnInit() {
   
}}
