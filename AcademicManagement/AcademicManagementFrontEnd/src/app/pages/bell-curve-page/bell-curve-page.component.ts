import { Component, OnInit, HostBinding } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FinalGradeService } from 'src/app/services/final-grade.service';

@Component({
  selector: 'app-bell-curve-page',
  templateUrl: './bell-curve-page.component.html',
  styleUrls: ['./bell-curve-page.component.scss']
})
export class BellCurvePageComponent implements OnInit {

  @HostBinding('class') classes = 'page-wrapper';

  courseId: string;
  data : number[] =[];
  
  constructor(private route: ActivatedRoute,private finalGradeService: FinalGradeService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
      this.getFinalGrades();

    });
  }

  getFinalGrades() {
    this.finalGradeService.getAllByCourse(this.courseId).subscribe(x => {
        x.forEach(val => {
            this.data.push( + val.value);
        })
    })
}

}
