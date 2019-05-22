import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FileService } from 'src/app/services/file-upload.service';
import { HttpEventType, HttpClient, HttpRequest } from '@angular/common/http';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent implements OnInit {

  @Input() courseId: string;
  
  fileToUpload: File = null;
  progress: number;
  message: string;
 files: any;

constructor(private http: FileService) { 
}

ngOnInit() {
  this.loadFiles();
}


public upload = (files) => {
  if (files.length === 0) {
    return;
  }

  let fileToUpload = <File>files[0];
 

  this.http.postFile(fileToUpload, this.courseId)
    .subscribe(event => {
    });
}


loadFiles(){
  this.http.getByCourseId(this.courseId).subscribe(response => 
    {this.files = response;
      this.files.forEach(element => {
        let url = window.URL.createObjectURL(new Blob(element.path));
        let a = document.createElement('a');
        document.body.appendChild(a);
        a.setAttribute('style', 'display: none');
        a.href = url;
        a.download = element.fileName;
        a.click();
        window.URL.revokeObjectURL(url);
        a.remove();
      });
    })
}


}
  
