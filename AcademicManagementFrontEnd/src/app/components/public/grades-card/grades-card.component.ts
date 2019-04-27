import { Component, OnInit, Input, Inject, Injectable } from '@angular/core';
import { GradeService } from 'src/app/services/grade-service.service';
import { Grade } from 'src/app/models/grade';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-grades-card',
  templateUrl: './grades-card.component.html',
  styleUrls: ['./grades-card.component.scss']
})
export class GradesCardComponent implements OnInit {

  @Input() grades:Grade[];
  
  constructor( ) { }

  ngOnInit() {
  }


}
