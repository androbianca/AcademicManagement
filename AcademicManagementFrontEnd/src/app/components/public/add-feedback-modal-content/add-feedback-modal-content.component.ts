import { Component, OnInit, Inject, Input } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Feedback } from 'src/app/models/feedback';
import { UserDetails } from 'src/app/models/userDetails';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FeedbackService } from 'src/app/services/feedback-service.service';
import { SignalRService } from 'src/app/services/signalR-service.service';

@Component({
  selector: 'app-add-feedback-modal-content',
  templateUrl: './add-feedback-modal-content.component.html',
  styleUrls: ['./add-feedback-modal-content.component.scss']
})
export class AddFeedbackModalContentComponent {

  feedback = new Feedback();
  user: UserDetails;
  isDisabled = true;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<AddFeedbackModalContentComponent>,
    private userDetailsService: CurrentUserDetailsService,
    private signalRService: SignalRService,
    private feedbackSvice: FeedbackService, private snackBar: MatSnackBar) {
    this.user = this.userDetailsService.getUser();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  onFormChange(form) {
    if (form.valid) {
      this.isDisabled = false;
      this.feedback.body = form.value.feedback;
      this.feedback.professorId = this.data.reciverId;
      if (!form.value.anonim) {
        this.feedback.studentId = this.user.id;
      }
      else {
        this.feedback.studentId = null;
      }
    }
  }
  public sendMessage(): void {
    this.signalRService._hubConnection.invoke("NewMessage");
  }
  
  save() {
    this.feedbackSvice.addFeedback(this.feedback).subscribe(response => {
      this.snackBar.open("succes");
      this.sendMessage();

    }, err => {
      this.snackBar.open("fail");
    });
  }

}
