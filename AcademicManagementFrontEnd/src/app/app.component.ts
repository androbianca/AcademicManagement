import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { CurrentUserDetailsService } from './services/current-user-details.service';
import { UserDetails } from './models/userDetails';
import { MatDialog } from '@angular/material/dialog';
import { AlertModalComponent } from './components/public/others/alert-modal/alert-modal.component';
import { AlertHub } from './services/SignalR/alerts-hub.service';
import { AlertService } from './services/alert.sevice';
import { Role } from './models/role-enum';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  ngOnInit(): void {
    this.registerOnServerEvents();

  }

  title = 'AcademicManagementFrontEnd';
  home = false;
  route: string;
  user: UserDetails;
  role: typeof Role = Role;
  isProfessor = false;

  constructor(private router: Router,
    public dialog: MatDialog,
    private alertService: AlertService,
    private currentUserDetailsService: CurrentUserDetailsService,
    private alertHub: AlertHub
  ) {

    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      this.route = this.router.url;
      this.home = this.route === '/' ? true : false;
    });
    this.currentUserDetailsService.getUserObservable().subscribe(result => {
      this.user = result;
      this.isProfessor = this.user.userRole == this.role.professor ? true : false;

    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AlertModalComponent, {
      width: '300px',
      height: '200px',
      panelClass: 'my-dialog-container-class'
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  getAlerts() {
    this.alertService.getAlert(this.user.userCode).subscribe(x => {
      if (x) {
        this.openDialog();
      }
    })
  }


  public registerOnServerEvents(): void {
    this.alertHub._hubConnection.on('alert', () => {
      this.getAlerts();
    });
  }
}
