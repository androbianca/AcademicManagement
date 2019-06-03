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
  @Output() noResources = new EventEmitter<boolean>();
  
  hasResources: boolean;
  files: FileModel[];
  link: string;
  resource = new Array<Resource>();

  constructor(private http: FileService) {
  }

  ngOnInit() {
    this.loadFiles();
  }

  loadFiles() {
    this.http.getByCourseId(this.courseId).subscribe(response => {
      this.files = response;
      this.hasResources = this.files.length <= 0 ? false : true;
      this.noResources.emit(this.hasResources);
      this.files.forEach(element => {
        this.resource.push({ file: element, link: `../../../../assets/files/${this.courseId}/${element.fileName}` })
      })
    });
  }

}

