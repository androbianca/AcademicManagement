import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FileService } from 'src/app/services/file-upload.service';
import { FileModel } from 'src/app/models/file';

export interface Resource {
  file: FileModel;
  link: string;
}

@Component({
  selector: 'app-file-download',
  templateUrl: './file-download.component.html',
  styleUrls: ['./file-download.component.scss']
})

export class FileDownloadComponent implements OnInit {

  @Input() courseId: string;
  @Input() resources;
  
  constructor() {
  }

  ngOnInit() {
    this.resources = this.resources.sort((a,b)=> {
      if(a.file.fileName > b.file.fileName){
        return 0;
      }
      return -1;
    })
  }

 

}

