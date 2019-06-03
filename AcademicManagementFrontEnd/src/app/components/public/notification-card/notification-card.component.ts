import { Component, OnInit, HostBinding, Input } from '@angular/core';
import { Notif } from 'src/app/models/notification';

@Component({
  selector: 'app-notification-card',
  templateUrl: './notification-card.component.html',
  styleUrls: ['./notification-card.component.scss']
})
export class NotificationCardComponent implements OnInit {

  @Input() notification: Notif;
  @HostBinding('class') classes = "notification-card";

  initials:string;

  constructor() { }

  ngOnInit() {
    this.initials = this.notification.body.split(' ')[0][0] + ' ' + this.notification.body.split(' ')[1][0];
  }
}
