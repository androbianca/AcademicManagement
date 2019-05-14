import { EventEmitter, Injectable } from '@angular/core';  
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';  
  
@Injectable()  
export class SignalRService {  
  connectionEstablished = new EventEmitter<Boolean>();  
  
  private connectionIsEstablished = false;  
  private _hubConnection: HubConnection;  
  
  constructor() {  
    this.createConnection();  
    this.registerOnServerEvents();  
    this.startConnection();  
  }  
  
  private createConnection() {  
    this._hubConnection = new HubConnectionBuilder()  
      .withUrl('/notify') 
      .build();  
  }  
  
  private startConnection(): any {  
    this._hubConnection  
      .start()  
      .then(() => {  
        this.connectionIsEstablished = true;  
        console.log('Hub connection started');  
        this.connectionEstablished.emit(true);  
      })  
      .catch(err => {  
        console.log('Error while establishing connection, retrying...');  
        setTimeout(this.startConnection(), 5000);  
      });  
  }  
  
  private registerOnServerEvents(): void {  
    this._hubConnection.on('ReceiveMessage', (data: any) => {  
     console.log(data) 
    });  
  }  
}  