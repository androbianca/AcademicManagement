import { EventEmitter, Injectable } from '@angular/core';  
import { HubConnectionBuilder, HubConnection, HttpTransportType, LogLevel } from '@aspnet/signalr';
import { NotificationService } from './notification-service.service';
  
@Injectable({
  providedIn: 'root'
})
export class SignalRService {  
  connectionEstablished = new EventEmitter<Boolean>();  
  
  private connectionIsEstablished = false;  
  private _hubConnection: HubConnection;  
  
  constructor(private notificatonSrvice:NotificationService) {  
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
    this.notificatonSrvice.get().subscribe(x=>console.log(x));   
   });  
  }  
}  