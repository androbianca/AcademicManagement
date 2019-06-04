import { EventEmitter, Injectable } from '@angular/core';
import { HubConnectionBuilder, HubConnection, HttpTransportType, LogLevel } from '@aspnet/signalr';
import { NotificationService } from './notification-service.service';
import { Post } from '../models/post';
import { PostService } from './post-service.service';
import { Notif } from '../models/notification';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  connectionEstablished = new EventEmitter<Boolean>();

  private connectionIsEstablished = false;
  private _hubConnection: HubConnection;
  notifications: Notif[];
  posts: Post[];
  notifNumber: number = 0;

  constructor(private notificatonSrvice: NotificationService,
    private postService: PostService) {
    this.createConnection();
    this.registerOnServerEvents();
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

  public registerOnServerEvents(): void {
    this._hubConnection.on('ceva', () => {
      this.notificatonSrvice.get().subscribe(x => {
        this.notifNumber = 0;
        this.notifications = x;
        this.notifications = x.sort((val1, val2) => {
          return new Date(val2.time).getTime() - new
            Date(val1.time).getTime()
        })
        this.notifications.forEach(notif => {
          if (!notif.isRead) {
            this.notifNumber+= 1;
          }
        })
      });

      this.postService.getAll().subscribe(x => {

        this.posts = x.sort((val1, val2) => {
          return new Date(val2.time).getTime() - new
            Date(val1.time).getTime()
        })
      })
    });
  }
}  