import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student-service.service';
import { ActivatedRoute } from '@angular/router';
import { GradeCategoryService } from 'src/app/services/grade-category.service';
import { GradeService } from 'src/app/services/grade-service.service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Student } from 'src/app/models/student';
import { Grade } from 'src/app/models/grade';
import { GradeCategory } from 'src/app/models/grade-category';

@Component({
  selector: 'app-see-grades',
  templateUrl: './see-grades.component.html',
  styleUrls: ['./see-grades.component.scss']
})
export class SeeGradesComponent implements OnInit {

  courseId: string;
  profId: string;
  students : Student[];
  grades :Grade[]
  studGrades : any[] =[];
  categories : GradeCategory[];

  constructor(private studentService:StudentService, 
    private route: ActivatedRoute,
    private categoryService:GradeCategoryService,
    private gradeService:GradeService
    ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
    });
    this.route.params.subscribe(params => {
      this.profId = params['profId'];
    });
    this.getStudents();
    this.getCategories();
  }

  getCategories(){
    this.categoryService.getByCourseId(this.courseId).subscribe(x => {
      this.categories=x;
      console.log(this.categories)
    });
  }

  getStudents(){
  this.studentService.getStudentsByProf(this.courseId).subscribe((x:Student[]) => {
    x.forEach(student => {
      this.gradeService.getGrades(this.courseId,student.id).subscribe(x => {
        this.grades = x;
        this.studGrades.push({'student': student,'grades':this.grades})
      })
    })
  })
  }

  getStudGrades(studentId){
   
    return this.grades;
  }

}
