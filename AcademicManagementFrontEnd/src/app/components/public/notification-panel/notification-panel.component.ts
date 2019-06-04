import { Component, OnInit, EventEmitter } from '@angular/core';
import { SignalRService } from 'src/app/services/signalR-service.service';
import { Notif } from 'src/app/models/notification';

@Component({
  selector: 'app-notification-panel',
  templateUrl: './notification-panel.component.html',
  styleUrls: ['./notification-panel.component.scss']
})
export class NotificationPanelComponent implements OnInit {

  notifications :Notif[];
  constructor(private signalRService: SignalRService ) { }

  ngOnInit() {
    this.notifications = this.signalRService.notifications;

  }

}
