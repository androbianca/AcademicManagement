import { Component, OnInit, ViewChild, AfterViewInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Comm } from 'src/app/models/comment';
import { CommService } from 'src/app/services/comment.service';
import { UserDetails } from 'src/app/models/userDetails';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { SignalRService } from 'src/app/services/signalR-service.service';


@Component({
  selector: 'app-comment-card',
  templateUrl: './comment-card.component.html',
  styleUrls: ['./comment-card.component.scss']
})
export class CommentCardComponent {

  @Input() postId: string;

  user: UserDetails;
  initials:string;
  comment = new Comm();
  commentForm = new FormGroup({
    comment: new FormControl("", [Validators.required]),
  });

  constructor(private commentService: CommService,
    private signalRService: SignalRService,
    private currentUserDetailsService: CurrentUserDetailsService) {
    this.user = this.currentUserDetailsService.getUser();
    this.initials = this.user.lastName[0] + ' ' + this.user.firstName[0];
    this.comment.userCode = this.user.userCode;
  }

  public sendMessage(): void {
    this.signalRService._hubConnection.invoke("NewMessage");
  }

  submit(event) {
    event.preventDefault();
    if (event.code == "Enter" && this.commentForm.valid) {
      this.comment.body = this.commentForm.value.comment;
      this.comment.postId = this.postId;
      this.commentService.postComment(this.comment).subscribe(x => this.sendMessage());
    }
  }
}
