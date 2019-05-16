import { BaseService } from './base-service.service';
import { Injectable } from '@angular/core';
import { Feedback } from '../models/feedback';


@Injectable({
    providedIn: 'root'
})
export class FeedbackService {

    constructor(private baseService: BaseService) {
    }

    public addFeedback(feedback: Feedback) {
        return this.baseService.post<Feedback>('feedback', feedback);
    }

    public getByProfId(studId: string) {
        return this.baseService.get<Feedback[]>(`feedback/${studId}`);
    }
}
