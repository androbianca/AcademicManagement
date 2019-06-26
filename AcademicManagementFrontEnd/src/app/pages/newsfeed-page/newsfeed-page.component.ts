import { Component, OnInit, HostBinding, ɵConsole } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Post } from 'src/app/models/post';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { PostService } from 'src/app/services/post-service.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { NotificationHub } from 'src/app/services/SignalR/notifications-hub.service';
import { FeedHub } from 'src/app/services/SignalR/feed-hub.service';
import { Role } from 'src/app/models/role-enum';

@Component({
  selector: 'app-newsfeed-page',
  templateUrl: './newsfeed-page.component.html',
  styleUrls: ['./newsfeed-page.component.scss']
})
export class NewsfeedPageComponent implements OnInit {

  @HostBinding('class') classes = "page-wrapper";
  post = new Post();
  user: UserDetails;
  postId: string;
  isDisabled = true;
  posts = new Array<Post>();
  role: typeof Role = Role;
  isStudent = false;

  postForm = new FormGroup({
    post: new FormControl("", [Validators.required]),
  });
  _hubConnection1: any;

  constructor(private userDetailsService: CurrentUserDetailsService,
    private postService: PostService,
    private router:Router,
    private feedHub:FeedHub,
    private notificationHub:NotificationHub,
    private snackBar: MatSnackBar) {
    this.user = this.userDetailsService.getUser();
    this.isStudent = this.user.userRole == this.role.student ? true : false;

  }

  ngOnInit() {
    this.getPosts();
    this.onChanges();
    this.registerOnServerEvents();
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  getPosts() {
    this.postService.getAll().subscribe(x => {
      this.posts = x.sort((val1, val2) => {
        return new Date(val2.time).getTime() - new
          Date(val1.time).getTime()
      })
    })
  }

  onChanges(): void {
    this.postForm.valueChanges.subscribe(x => {
      this.isDisabled = this.postForm.valid ? false : true;
    })
  }

  
  public registerOnServerEvents(): void {
    this.feedHub._hubConnection.on('post', () => {
      this.getPosts();
    });
  }

  public sendMessage(): void {
    this.feedHub._hubConnection.invoke("NewPost");
    this.notificationHub._hubConnection.invoke("NewNotification");
  }


  addPost(postForm) {
    if (this.postForm.valid) {
      this.post.body = postForm.value.post;
      this.post.userCode = this.user.userCode;
      this.postService.add(this.post).subscribe(response => {
        this.snackBar.open("success")
        this.sendMessage();
      }, err => {
      }
      )
    }
  }

  onFileUpload(event){
    this.postId = event.courseId;
  }

  goTo(){
    this.router.navigate([`optionals`]);
  }
}
