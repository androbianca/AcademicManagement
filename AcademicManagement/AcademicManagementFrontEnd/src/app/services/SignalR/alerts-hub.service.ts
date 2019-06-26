import { EventEmitter, Injectable } from '@angular/core';
import { HubConnectionBuilder, HubConnection, LogLevel } from '@aspnet/signalr';

@Injectable({
    providedIn: 'root'
})

export class AlertHub {
    connectionEstablished = new EventEmitter<Boolean>();
    private connectionIsEstablished = false;
    _hubConnection: HubConnection;


    constructor() {
        this.createConnection();
        this.startConnection();
    }

    public createConnection() {
        this._hubConnection = new HubConnectionBuilder()
            .withUrl('https://localhost:44304/alerts')
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