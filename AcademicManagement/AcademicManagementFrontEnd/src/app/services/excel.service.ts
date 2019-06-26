import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { FileModel } from '../models/file';


@Injectable({
    providedIn: 'root'
})
export class ExcelService {

    constructor(private baseService: BaseService) { }


    postExcelFile(fileToUpload: File, courseId: string) {
        let formData: FormData = new FormData();
        formData.append('file', fileToUpload);
        return this.baseService.postFile(`excel/${courseId}`, formData);
    }

}
