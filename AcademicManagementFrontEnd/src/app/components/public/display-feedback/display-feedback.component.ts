import { Component, Input, AfterContentInit, ContentChildren, OnInit } from '@angular/core';
import { FeedbackStud } from 'src/app/pages/prof-profile/prof-profile.component';
import { Feedback } from 'src/app/models/feedback';
import { FeedbackService } from 'src/app/services/feedback-service.service';
import { ActivatedRoute } from '@angular/router';
import { StudentService } from 'src/app/services/student-service.service';
import { Student } from 'src/app/models/student';

export class SlideShow {
  isActive: boolean;
  feedbackStud: any;
  slideNumber: number;
}

@Component({
  selector: 'app-display-feedback',
  templateUrl: './display-feedback.component.html',
  styleUrls: ['./display-feedback.component.scss']
})
export class DisplayFeedbackComponent implements OnInit {


  @Input() profId: string;

  slideShow = new Array<SlideShow>();
  slideIndex = 0;
  feedbackStud = new Array<any>();
  feedbackList = new Array<Feedback>();
  x: any;

  constructor(private feedbackService: FeedbackService, private studentService: StudentService) {
  }

  ngOnInit(): void {
    this.getFeedback();
  }

  getFeedback() {
    this.feedbackService.getByProfId(this.profId).subscribe(response => {
      this.feedbackList = response;
      this.getStudent();
    })
  }

  getStudent() {
    this.feedbackList.forEach((item, index) => {
      if (item.studentId) {
        this.studentService.getById(item.studentId).subscribe(x => {
          this.feedbackStud.push({
            'Body': item.body,
            'UserName': x.lastName + ' ' + x.firstName,
            'Initials': x.lastName[0] + ' ' + x.firstName[0],
            'isActive': false,
            'slideNumber': index
          });
        })
      }
      else {
        this.feedbackStud.push({
          'Body': item.body,
          'UserName': 'Unknown',
          'Initials': 'U',
          'isActive': false,
          'slideNumber': index
        });
      }

    })

    this.feedbackStud[0].isActive = true;
  }


  plusSlides(n) {
    if ((this.slideIndex + n) < 0) {
      this.slideIndex = this.feedbackStud.length
    }

    if ((this.slideIndex + n) >= this.feedbackStud.length) {
      this.slideIndex = 0;
    }
    this.showSlides(this.slideIndex + n);
  }

  currentSlide(n) {
    this.showSlides(n);
  }


  showSlides(n) {
    this.feedbackStud.forEach(slide => {
      slide.isActive = n == slide.slideNumber ? true : false;
    })
    this.slideIndex = n;
  }
}
