import { EventEmitter, Injectable } from '@angular/core';
import { HubConnectionBuilder, HubConnection, HttpTransportType, LogLevel } from '@aspnet/signalr';
import { NotificationService } from './notification-service.service';
import { Post } from '../models/post';
import { PostService } from './post-service.service';
import { Notif } from '../models/notification';
import { AlertService } from './alert.sevice';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  connectionEstablished = new EventEmitter<Boolean>();

  private connectionIsEstablished = false;
   _hubConnection: HubConnection;

  constructor(
    private postService: PostService,
    private alertService: AlertService
  ) {
    this.createConnection();
    this.startConnection();
  }

  public createConnection() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:44304/notify')
      .configureLogging(LogLevel.Information)
      .build();
  }

  public startConnection(): any {
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
      })
      .catch(err => {
        console.log(err);
        setTimeout(this.startConnection(), 5000);
      });
  }

}  