import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { CurrentUserDetailsService } from './services/current-user-details.service';
import { UserDetails } from './models/userDetails';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Notification } from 'rxjs';
import { Notif } from './models/notification';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {

  private _hubConnection: HubConnection;
  msgs: Notif[] = [];
  
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
 
  ngOnInit(): void {
    this._hubConnection = new HubConnectionBuilder()
            .withUrl('https://localhost:44304/api/notifications')
            .build();

    this._hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

    this._hubConnection.on('BroadcastMessage', (title: string, body: string) => {
      this.msgs.push({'title':title, 'body':body});
    });
  }

}
