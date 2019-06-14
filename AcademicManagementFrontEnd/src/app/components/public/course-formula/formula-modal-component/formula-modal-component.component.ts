import { Component, OnInit, Inject } from '@angular/core';
import { AddFormulaComponent } from '../add-formula/add-formula.component';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-formula-modal-component',
  templateUrl: './formula-modal-component.component.html',
  styleUrls: ['./formula-modal-component.component.scss']
})
export class FormulaModalComponentComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<AddFormulaComponent>) { }

  ngOnInit() {
  }

}
