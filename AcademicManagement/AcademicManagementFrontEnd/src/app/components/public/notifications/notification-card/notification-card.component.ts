import { Component, OnInit, HostBinding, Input, HostListener } from '@angular/core';
import { Notif } from 'src/app/models/notification';
import { Router } from '@angular/router';
import { GradeService } from 'src/app/services/grade-service.service';
import { NotificationService } from 'src/app/services/notification-service.service';
import { DatePipe } from '@angular/common';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import * as moment from 'moment'
import { NotificationHub } from 'src/app/services/SignalR/notifications-hub.service';
let myMoment: moment.Moment = moment("someDate");

@Component({
  selector: 'app-notification-card',
  templateUrl: './notification-card.component.html',
  styleUrls: ['./notification-card.component.scss']
})
export class NotificationCardComponent implements OnInit {

  @Input() notification: Notif;
  @HostBinding('class') classes = "notification-card";
  pipe = new DatePipe('en-US'); // Use your own locale
  date: any;
  @HostListener('click', ['$event.target'])
  onClick() {
    this.updateNotification();
    this.goTo();
  }
  text = "New grade";
  route = "";
  profId: string;
  initials: string;
  user: UserDetails;

  constructor(private router: Router, private gradeService: GradeService,
    private notificationService: NotificationService,
    private currentUser: CurrentUserDetailsService,
    private notificationHub:NotificationHub,
    ) {
    this.user = this.currentUser.getUser();
  }

  public sendMessage(): void {
    this.notificationHub._hubConnection.invoke("NewNotification");
  }

  ngOnInit() {
    this.initials = this.notification.body.split(' ')[0][0] + ' ' + this.notification.body.split(' ')[1][0];
    this.date = moment(this.notification.time, "YYYYMMDD hh:mm").fromNow();

    if (this.notification.title.toLowerCase().trim() == this.text.toLocaleLowerCase().trim()) {
      this.gradeService.getById(this.notification.itemId).subscribe(result => {
        this.route = `grades/${result.courseId}`;
      })
      return;
    }

    this.route = this.notification.title.toLowerCase().trim() == "New feedback".toLowerCase().trim() ? `professors/${this.user.id}` :'newsfeed'; 
  }

  goTo() {
    this.router.navigate([this.route]);
  }

  updateNotification() {
    this.notificationService.read(this.notification).subscribe(x =>{this.sendMessage();
    })
  }


}
