import { Component, Input } from '@angular/core';
import { FileService } from 'src/app/services/file-upload.service';
import { ExcelService } from 'src/app/services/excel.service';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})

export class FileUploadComponent {

  @Input() courseId: string;

  @Input() isExcel: boolean = false;

  @Input() title: string;

  fileToUpload: File = null;

  constructor(private fileService: FileService, private excelService: ExcelService) {
  }

  public upload = (files) => {
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];

    this.fileService.postFile(fileToUpload, this.courseId, this.isExcel)
      .subscribe(event => {
      });
  }
}

