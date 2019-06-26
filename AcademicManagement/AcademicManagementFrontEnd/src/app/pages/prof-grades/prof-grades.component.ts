import { Component, OnInit, HostBinding } from '@angular/core';
import { StudentService } from 'src/app/services/student-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { Student } from 'src/app/models/student';
import { MatDialog } from '@angular/material/dialog';
import { GradeCategoryModalComponentComponent } from 'src/app/components/public/grade-categories/grade-category-modal-component/grade-category-modal-component.component';
import { GroupService } from 'src/app/services/group-service.service';
import { GroupRead } from 'src/app/models/groupRead';
import { CategoriesModalComponent } from 'src/app/components/public/grade-categories/categories-modal/categories-modal.component';

import { CoureFormulaService } from 'src/app/services/course-formula.service';
import { FormulaModalComponentComponent } from 'src/app/components/public/course-formula/formula-modal-component/formula-modal-component.component';

@Component({
  selector: 'app-prof-grades',
  templateUrl: './prof-grades.component.html',
  styleUrls: ['./prof-grades.component.scss']
})
export class ProfGradesComponent implements OnInit {

  @HostBinding('class') classes = 'page-wrapper';

  courseId: string;
  user: UserDetails;
  students = new Array<Student>();
  groups: GroupRead[];
  studs: any;
  filteredStudents = new Array<Student>();


  constructor(private studentService: StudentService,
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private router: Router,
    private groupService: GroupService,
    private courseFormulaService: CoureFormulaService,
    private userDetailsService: CurrentUserDetailsService) {
    this.user = userDetailsService.getUser();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
    });
    this.getGroups();
  }

  getStudents(){
    this.studentService.getStudentsByProf(this.courseId).subscribe((result: Student[]) => {
      this.students = result;
      this.filteredStudents = this.students.filter(x => x.groupId == this.groups[0].id);
    });
  }

  goTo(route) {
    this.router.navigate([`${route}/${this.courseId}`]);
  }

  goToGrades(route){
    this.router.navigate([`${route}/${this.courseId}/${this.user.id}`]);
  }

  openModal() {
    const dialogRef = this.dialog.open(GradeCategoryModalComponentComponent, {
      width: '390px',
      data: { courseId: this.courseId }
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  getGroups() {
    this.groupService.getProfGroups(this.user.id, this.courseId).subscribe(x => {
    this.groups = x
    this.getStudents();
    })
  }

  filterStudents(group) {
    this.filteredStudents = this.students.filter(x => x.groupId == group.id);
  }


  openCategoryDialog(): void {
    const dialogRef = this.dialog.open(CategoriesModalComponent, {
      width: '400px',
      data: { courseId: this.courseId }
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  openFormulaDialog(): void {
    const dialogRef = this.dialog.open(FormulaModalComponentComponent, {
      width: '600px',
      data: { courseId: this.courseId }
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }
}
