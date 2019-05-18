import { Component, OnInit, HostBinding } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Post } from 'src/app/models/post';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { PostService } from 'src/app/services/post-service.service';
import { SignalRService } from 'src/app/services/signalR-service.service';

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
    post: new FormControl(null,[Validators.required]),
  });
  isDisabled= false;
  constructor(private userDetailsService: CurrentUserDetailsService,
    private postService: PostService,private signalRService: SignalRService) {
    this.user = this.userDetailsService.getUser();
  }

  ngOnInit() {
    this.getPosts();
  }

  getPosts() {
    this.postService.getAll().subscribe(response => {
      this.posts = response;
    })
  }

  onChanges(): void {
    this.postForm.valueChanges.subscribe(x=> {
    this.isDisabled = this.postForm.valid ? false :true;
    })
  }

  addPost(postForm) {
    if (this.postForm.valid) {
      this.post.body = postForm.value.post;
      this.post.userCode = this.user.userCode;

      this.postService.add(this.post).subscribe(x => console.log(x))

    }
  }

}
