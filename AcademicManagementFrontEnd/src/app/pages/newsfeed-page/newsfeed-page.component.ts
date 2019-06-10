import { Component, OnInit, HostBinding, ɵConsole } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Post } from 'src/app/models/post';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { PostService } from 'src/app/services/post-service.service';
import { SignalRService } from 'src/app/services/signalR-service.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

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

  postForm = new FormGroup({
    post: new FormControl("", [Validators.required]),
  });
  _hubConnection: any;

  constructor(private userDetailsService: CurrentUserDetailsService,
    private postService: PostService, private signalRService: SignalRService,
    private router:Router,
    private snackBar: MatSnackBar) {
    this.user = this.userDetailsService.getUser();
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
    this.signalRService._hubConnection.on('message', () => {
      this.getPosts();
    });
  }

  public sendMessage(): void {
    this.signalRService._hubConnection.invoke("NewMessage");
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
