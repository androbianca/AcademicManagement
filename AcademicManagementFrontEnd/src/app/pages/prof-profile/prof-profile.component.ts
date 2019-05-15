import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course-service.service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { ActivatedRoute } from '@angular/router';
import { CourseRead } from 'src/app/models/course-read';

@Component({
  selector: 'app-prof-profile',
  templateUrl: './prof-profile.component.html',
  styleUrls: ['./prof-profile.component.scss']
})
export class ProfProfileComponent implements OnInit {

  profId: string;
  courses:CourseRead[];
  constructor(private courseService:CourseService,private route:ActivatedRoute) { }

  ngOnInit() {
    this.getCourses();
  }

  getCourses(){
    this.route.params.subscribe(params => {
      this.profId = params['profId'];
    });
   this.courseService.getProfCourses(this.profId ).subscribe(response => {
     this.courses = response;
   })
  }

}
