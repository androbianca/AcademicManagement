import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { CurrentUserDetailsService } from './current-user-details.service';
import { UserDetails } from '../models/userDetails';
import { CourseRead } from '../models/course-read';
import { Comm } from '../models/comment';

@Injectable({
    providedIn: 'root'
})
export class CommService {

    public user: UserDetails;
    constructor(private baseService: BaseService) {
    }

    public postComment(commment: Comm) {
        return this.baseService.post<Comm>('comments', commment);
    }

    public getByPostId(postId:string) {
        return this.baseService.get<Comm[]>(`comments/${postId}`);
    }
}
