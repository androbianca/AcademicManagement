import { Component, OnInit, Input } from "@angular/core";
import { CdkConnectedOverlay, Overlay, ScrollStrategy, CdkOverlayOrigin } from '@angular/cdk/overlay';
import { SignalRService } from 'src/app/services/signalR-service.service';
import { NotificationService } from 'src/app/services/notification-service.service';
import { Notif } from 'src/app/models/notification';

@Component({
  selector: "app-top-bar",
  templateUrl: "./top-bar.component.html",
  styleUrls: ["./top-bar.component.scss"]
})
export class TopBarComponent implements OnInit {

  panelOpen = false;
  notifications: Notif[];
  notifNumber: number = 0

  constructor(protected overlay: Overlay,private signalRService: SignalRService,
    private notificatonService: NotificationService) { }

  ngOnInit(): void {
    this.getNotifications();
    this.registerOnServerEvents();

  }

  public registerOnServerEvents(): void {
    this.signalRService._hubConnection.on('message', () => {
      this.getNotifications();
    });
  }

  getNotifications() {
    this.notificatonService.get().subscribe(x => {
      this.notifNumber = 0;
      this.notifications = x;
      this.notifications = x.sort((val1, val2) => {
        return new Date(val2.time).getTime() - new
          Date(val1.time).getTime()
      })
      this.notifications.forEach(notif => {
        if (!notif.isRead) {
          this.notifNumber += 1;
        }
      })
    });
  }

  toggle() {
    this.panelOpen ? this.close() : this.open();
  }

  close() {
    this.panelOpen = false;
  }

  open() {
    this.panelOpen = true;
  }

}
