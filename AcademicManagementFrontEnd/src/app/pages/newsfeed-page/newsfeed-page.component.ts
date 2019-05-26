import { Component, OnInit, HostBinding, ɵConsole } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Post } from 'src/app/models/post';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { PostService } from 'src/app/services/post-service.service';
import { SignalRService } from 'src/app/services/signalR-service.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-newsfeed-page',
  templateUrl: './newsfeed-page.component.html',
  styleUrls: ['./newsfeed-page.component.scss']
})
export class NewsfeedPageComponent implements OnInit {

  post = new Post();
  user: UserDetails;
  posts = new Array<Post>();
  // @HostBinding('class') classes = "page-wrapper";
  postForm = new FormGroup({
    post: new FormControl(null, [Validators.required]),
  });
  postId: string;

  isDisabled = true;
  constructor(private userDetailsService: CurrentUserDetailsService,
    private postService: PostService, private signalRService: SignalRService,
    private snackBar: MatSnackBar) {
    this.user = this.userDetailsService.getUser();
    this.posts = this.signalRService.posts;
  }

  ngOnInit() {
    this.getPosts();
    this.onChanges();
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  getPosts() {
    this.postService.getAll().subscribe(response => {
      this.posts = response;
      this.posts = this.posts.sort((x, y) => (new Date(x.time).getHours() - new Date(y.time).getHours())
      );
    })
  }

  onChanges(): void {
    this.postForm.valueChanges.subscribe(x => {
      this.isDisabled = this.postForm.valid ? false : true;
    })
  }

  addPost(postForm) {
    if (this.postForm.valid) {
      this.post.body = postForm.value.post;
      this.post.userCode = this.user.userCode;
      this.postService.add(this.post).subscribe(response => {
        this.snackBar.open("success")
      }, err => {
        this.snackBar.open("fail")
      }
      )
    }
  }

}
