import { Component, OnInit, EventEmitter, Input } from '@angular/core';
import { Notif } from 'src/app/models/notification';
import { NotificationService } from 'src/app/services/notification-service.service';

@Component({
  selector: 'app-notification-panel',
  templateUrl: './notification-panel.component.html',
  styleUrls: ['./notification-panel.component.scss']
})
export class NotificationPanelComponent implements OnInit {

  @Input() notifications;

  constructor( ) { }

  


  ngOnInit() {

  }

}
