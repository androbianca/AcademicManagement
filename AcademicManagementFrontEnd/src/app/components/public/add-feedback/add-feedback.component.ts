import { Component, OnInit, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { Feedback } from 'src/app/models/feedback';
import { FeedbackService } from 'src/app/services/feedback-service.service';

@Component({
  selector: 'app-add-feedback',
  templateUrl: './add-feedback.component.html',
  styleUrls: ['./add-feedback.component.scss']
})
export class AddFeedbackComponent implements OnInit {
  @Input() reciverId: string;
  user: UserDetails;
  feedback = new Feedback();

  feedbackForm = new FormGroup({
    feedback: new FormControl(''),
  });

  constructor(private userDetailsService: CurrentUserDetailsService, private feedbackSvice: FeedbackService) {
    this.user = this.userDetailsService.getUser();
  }

  ngOnInit() {
  }

  addFeedback(form) {
    this.feedback.body = form.value.feedback;
    this.feedback.professorId = this.reciverId;
    this.feedback.studentId = this.user.id;
    this.feedbackSvice.addFeedback(this.feedback).subscribe(response =>{ console.log(response)});
  }

}
