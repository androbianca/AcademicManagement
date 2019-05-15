import { Component, OnInit } from '@angular/core';
import { ProfService } from 'src/app/services/prof-service.service';
import { ActivatedRoute } from '@angular/router';
import { Professor } from 'src/app/models/professor';

@Component({
  selector: 'app-course-profile',
  templateUrl: './course-profile.component.html',
  styleUrls: ['./course-profile.component.scss']
})
export class CourseProfileComponent implements OnInit {

  profs:Professor[];
  courseId:string;
  constructor(private profService:ProfService, private route:ActivatedRoute) { }

  ngOnInit() {
    this.getProfs();
  }

  getProfs(){
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
    });

    this.profService.getByCourseId(this.courseId).subscribe(response => {
      this.profs = response})
  }

}
