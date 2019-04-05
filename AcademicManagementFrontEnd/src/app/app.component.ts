import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { UserDetails } from './models/userDetails';
import { CurrentUserDetailsService } from './services/current-user-details.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {

  title = 'AcademicManagementFrontEnd';
  home = false;
  route: string;
  user = new UserDetails();
  constructor(private router: Router, private currentUserDetailsService:CurrentUserDetailsService) {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      this.route = this.router.url;
      this.home = this.route === '/' ? true : false;
    });
   
    this.currentUserDetailsService.getUserObservable().subscribe((user: UserDetails) => {
      if (user) {
        this.user = user;
      }
    })

  }

  ngOnInit() {
   
}}
