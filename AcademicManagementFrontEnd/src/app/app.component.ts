import { Component, OnInit } from '@angular/core';
import { Router, NavigationStart, NavigationEnd, ActivatedRoute } from '@angular/router';
import { filter } from 'rxjs/operators';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent  {

  title = 'AcademicManagementFrontEnd';
  home = false;
  route : string;
  constructor(private router: Router, private activatedRoute: ActivatedRoute ) {

    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
  ).subscribe(() => {
      this.route = this.activatedRoute.root.snapshot._routerState.url;
      this.home = this.route === "/" ? true : false;
  });
 

  }
}
