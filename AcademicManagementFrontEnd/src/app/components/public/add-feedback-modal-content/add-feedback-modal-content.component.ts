import { Component, OnInit, Inject, Input } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-add-feedback-modal-content',
  templateUrl: './add-feedback-modal-content.component.html',
  styleUrls: ['./add-feedback-modal-content.component.scss']
})
export class AddFeedbackModalContentComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,public dialogRef: MatDialogRef<AddFeedbackModalContentComponent>) { }

  ngOnInit() {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
  
}
