import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserDetails } from 'src/app/models/userDetails';
import { Feedback } from 'src/app/models/feedback';

@Component({
  selector: 'app-add-feedback',
  templateUrl: './add-feedback.component.html',
  styleUrls: ['./add-feedback.component.scss']
})
export class AddFeedbackComponent implements OnInit {

  @Output() formChanged = new EventEmitter<any>();

  user: UserDetails;
  feedback = new Feedback();
  isDisabled = true;

  feedbackForm = new FormGroup({
    feedback: new FormControl('', [Validators.required]),
    anonim: new FormControl('')
  });

  onChanges(): void {
    this.feedbackForm.valueChanges.subscribe(x => {
      this.isDisabled = this.feedbackForm.valid ? false : true;
      this.formChanged.emit(this.feedbackForm);
    })
  }

  ngOnInit() {
    this.onChanges();
  }
}
