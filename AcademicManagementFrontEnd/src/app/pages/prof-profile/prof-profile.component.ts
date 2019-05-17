import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course-service.service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { ActivatedRoute } from '@angular/router';
import { CourseRead } from 'src/app/models/course-read';
import { AddFeedbackModalContentComponent } from 'src/app/components/public/add-feedback-modal-content/add-feedback-modal-content.component';
import { MatDialog } from '@angular/material/dialog';
import { FeedbackService } from 'src/app/services/feedback-service.service';
import { StudentService } from 'src/app/services/student-service.service';
import { Feedback } from 'src/app/models/feedback';

export interface FeedbackStud{
   Body:string;
   UserName:string;
   Initials:string;
}

@Component({
  selector: 'app-prof-profile',
  templateUrl: './prof-profile.component.html',
  styleUrls: ['./prof-profile.component.scss']
})
export class ProfProfileComponent implements OnInit {

  profId: string;
  courses:CourseRead[];
  studId: string;
  feedbackStud  = new Array<FeedbackStud>();

  feedbackList = new Array<Feedback>();
  constructor(private courseService:CourseService,
    private route:ActivatedRoute,
    public dialog: MatDialog,
    private feedbackService:FeedbackService, 
    private studentSevice:StudentService) { 
      this.route.params.subscribe(params => {
        this.profId = params['profId'];
      });

    }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddFeedbackModalContentComponent, {
      width: '400px',
      height: '350px',
      data: { reciverId:this.profId }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  ngOnInit() {
    this.getCourses();
    this.getFeedback();

  }

  getCourses(){
   this.courseService.getProfCourses(this.profId ).subscribe(response => {
     this.courses = response;
   })
  }

  getFeedback(){
     this.feedbackService.getByProfId(this.profId).subscribe(response => {
       this.feedbackList = response;
       this.getStudent();
     })
  }

  getStudent(){
    this.feedbackList.forEach(item => {
      console.log(item.studentId);
      this.studentSevice.getById(item.studentId).subscribe(x=>{
        console.log(x);
           var name = x.lastName + ' ' + x.firstName;
           var initials =  x.lastName[0] + ' ' + x.firstName[0];
           this.feedbackStud.push({'Body':item.body, 'UserName':name, 'Initials': initials})
      })
    })

  }

}
