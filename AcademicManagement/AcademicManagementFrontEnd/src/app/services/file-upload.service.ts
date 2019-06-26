import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { FileModel } from '../models/file';


@Injectable({
    providedIn: 'root'
})
export class FileService {

    constructor(private baseService: BaseService) { }


    postFile(fileToUpload: File, courseId: string, isExcel:boolean) {
        let formData: FormData = new FormData();
        formData.append('file', fileToUpload);
        return this.baseService.postFile(`files/${courseId}/${isExcel}/upload`, formData);
    }

    getByCourseId(courseId: string){
        return this.baseService.get<FileModel[]>(`files/${courseId}`);
    }

}
