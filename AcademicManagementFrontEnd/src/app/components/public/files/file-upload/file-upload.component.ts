import { Component, Input, HostBinding, Output, EventEmitter } from '@angular/core';
import { FileService } from 'src/app/services/file-upload.service';
import { ExcelService } from 'src/app/services/excel.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})

export class FileUploadComponent {

  @Input() courseId: string = '8c6551de-2ad9-4699-aa3e-41b1e1ddcb62';
  @Input() isExcel: boolean = false;
  @Input() title: string;
  @Output() fileUploaded = new EventEmitter<any>();

  @HostBinding('class') classes = 'wrapper';

  fileToUpload: File = null;

  constructor(private fileService: FileService, 
    private excelService: ExcelService,
    private snackBar: MatSnackBar) {
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  onFileChanged(event) {
    var files = event.target.files;
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    this.fileService.postFile(fileToUpload, this.courseId, this.isExcel)
      .subscribe(result => {
        this.fileUploaded.emit(result);
        this.snackBar.open('success')
      },
      err => {
        this.snackBar.open('fail')

      });
  }
}

