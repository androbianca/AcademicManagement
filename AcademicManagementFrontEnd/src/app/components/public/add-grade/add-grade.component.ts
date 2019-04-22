import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-add-grade',
  templateUrl: './add-grade.component.html',
  styleUrls: ['./add-grade.component.scss']
})
export class AddGradeComponent implements OnInit {

  gradesForm = new FormGroup({
    purpose: new FormControl(''),
    value: new FormControl('')
  });

  constructor() { }

  ngOnInit() {
  }

}
