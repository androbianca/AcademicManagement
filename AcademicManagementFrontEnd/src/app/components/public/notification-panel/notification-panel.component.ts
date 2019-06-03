import { Component, OnInit } from '@angular/core';
import { SignalRService } from 'src/app/services/signalR-service.service';

@Component({
  selector: 'app-notification-panel',
  templateUrl: './notification-panel.component.html',
  styleUrls: ['./notification-panel.component.scss']
})
export class NotificationPanelComponent implements OnInit {

  notifications :Notification[];
  
  constructor(private signalRService: SignalRService ) { }

  ngOnInit() {
    this.notifications = this.signalRService.notifications;
  }

}
