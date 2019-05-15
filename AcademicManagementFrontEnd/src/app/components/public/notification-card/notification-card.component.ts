import { Component, OnInit, HostBinding, Input } from '@angular/core';

@Component({
  selector: 'app-notification-card',
  templateUrl: './notification-card.component.html',
  styleUrls: ['./notification-card.component.scss']
})
export class NotificationCardComponent implements OnInit {

  @Input() notification: Notification;
  @HostBinding('class') classes = "notification-card";
  constructor() { }

  ngOnInit() {
  }

}
