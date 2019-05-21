import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FileService } from 'src/app/services/file-upload.service';
import { HttpEventType, HttpClient, HttpRequest } from '@angular/common/http';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent {

  @Input() courseId: string;
  
  fileToUpload: File = null;
  progress: number;
  message: string;


constructor(private http: FileService) { }
public upload = (files) => {
  if (files.length === 0) {
    return;
  }

  let fileToUpload = <File>files[0];
 

  this.http.postFile(fileToUpload, this.courseId, )
    .subscribe(event => {
    
      
    });
}

}
  
