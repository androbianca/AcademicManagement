import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { Post } from '../models/post';

@Injectable({
    providedIn: 'root'
})

export class PostService {

    constructor(private baseService: BaseService) {}

     public add(post){
        return this.baseService.post<Post>('posts',post);
     }

     public getAll(){
        return this.baseService.get<Post[]>('posts');
     }
}
 