import { Component, OnInit, Inject } from '@angular/core';
import { DisplayCategoriesComponent } from '../display-categories/display-categories.component';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-categories-modal',
  templateUrl: './categories-modal.component.html',
  styleUrls: ['./categories-modal.component.scss']
})
export class CategoriesModalComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<DisplayCategoriesComponent>) { }

  ngOnInit() {
  }

}
