import { Component, OnInit, Input } from '@angular/core';
import { GradeCategoryService } from 'src/app/services/grade-category.service';
import { GradeCategory } from 'src/app/models/grade-category';

@Component({
  selector: 'app-display-categories',
  templateUrl: './display-categories.component.html',
  styleUrls: ['./display-categories.component.scss']
})
export class DisplayCategoriesComponent implements OnInit {

  @Input() courseId: string;
  categories: GradeCategory[];
  constructor(private gradeCategoryService: GradeCategoryService) { }

  ngOnInit() {
    this.gradeCategoryService.getByCourseId(this.courseId).subscribe(x => this.categories = x);
  }

}
