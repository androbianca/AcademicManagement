import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-grade-category-modal-component',
  templateUrl: './grade-category-modal-component.component.html',
  styleUrls: ['./grade-category-modal-component.component.scss']
})
export class GradeCategoryModalComponentComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
  public dialogRef: MatDialogRef<GradeCategoryModalComponentComponent>) { }

  ngOnInit() {
  }

}
