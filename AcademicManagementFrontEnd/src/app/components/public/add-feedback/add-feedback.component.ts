import { Component, OnInit, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
    feedback: new FormControl('', [Validators.required]),
  });
  isDisabled = true;

  constructor(private userDetailsService: CurrentUserDetailsService, private feedbackSvice: FeedbackService) {
    this.user = this.userDetailsService.getUser();
  }

  onChanges(): void {
    this.feedbackForm.valueChanges.subscribe(x => {
      this.isDisabled = this.feedbackForm.valid ? false : true;
    })
  }

  ngOnInit() {
    this.onChanges();
  }

  addFeedback(form) {
    if (this.feedbackForm.valid) {
      this.feedback.body = form.value.feedback;
      this.feedback.professorId = this.reciverId;
      this.feedback.studentId = this.user.id;
      this.feedbackSvice.addFeedback(this.feedback).subscribe(response => { console.log(response) });
    }
  }
}
