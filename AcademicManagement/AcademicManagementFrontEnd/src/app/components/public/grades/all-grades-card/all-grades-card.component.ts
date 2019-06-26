import { Component, OnInit, Input } from '@angular/core';
import { Student } from 'src/app/models/student';

@Component({
  selector: 'app-all-grades-card',
  templateUrl: './all-grades-card.component.html',
  styleUrls: ['./all-grades-card.component.scss']
})
export class AllGradesCardComponent implements OnInit {

  @Input() student;
  @Input() grades;
  @Input() categories;
  gradeCategory : any[] = [];

  constructor() { }

  ngOnInit() {
    this.categories.forEach(element => {
      console.log(this.grades)
      var grade = this.grades.find(x => x.category == element.name)
      grade ? this.gradeCategory.push({'category': element, 'grade':grade.value}) : this.gradeCategory.push({'category': element, 'grade':0})
    });
    console.log(this.gradeCategory);

  }

}
