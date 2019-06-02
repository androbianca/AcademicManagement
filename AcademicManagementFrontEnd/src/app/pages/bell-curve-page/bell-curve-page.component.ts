import { Component, OnInit, HostBinding } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-bell-curve-page',
  templateUrl: './bell-curve-page.component.html',
  styleUrls: ['./bell-curve-page.component.scss']
})
export class BellCurvePageComponent implements OnInit {
  @HostBinding('class') classes = 'page-wrapper';

  courseId: string;
  constructor(private route: ActivatedRoute) { 
    console.log('cplm')

  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
    });
  }

}
