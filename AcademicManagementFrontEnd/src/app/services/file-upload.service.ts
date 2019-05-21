import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { CurrentUserDetailsService } from './current-user-details.service';
import { UserDetails } from '../models/userDetails';
import { CourseRead } from '../models/course-read';

@Injectable({
    providedIn: 'root'
})
export class FileService {

    constructor(private baseService: BaseService) { }


    postFile(fileToUpload: File, courseId: string) {
        let formData: FormData = new FormData();
        formData.append('file', fileToUpload);
        return this.baseService.post(`files/${courseId}/upload`, formData);
    }

}
