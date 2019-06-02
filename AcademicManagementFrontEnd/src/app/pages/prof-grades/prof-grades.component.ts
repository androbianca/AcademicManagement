import { Component, OnInit, HostBinding } from '@angular/core';
import { StudentService } from 'src/app/services/student-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { Student } from 'src/app/models/student';
import { MatDialog } from '@angular/material/dialog';
import { AddFeedbackModalContentComponent } from 'src/app/components/public/add-feedback-modal-content/add-feedback-modal-content.component';
import { GradeCategoryModalComponentComponent } from 'src/app/components/public/grade-category-modal-component/grade-category-modal-component.component';
import { GroupService } from 'src/app/services/group-service.service';
import { GroupRead } from 'src/app/models/groupRead';

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
  filteredStudents = new Array<Student>();

  constructor(private studentService: StudentService,
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private router: Router,
    private groupService: GroupService,
    private userDetailsService: CurrentUserDetailsService) {
    this.user = userDetailsService.getUser();
  }


  ngOnInit() {
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
    });
    this.studentService.getStudentsByProf(this.courseId).subscribe((result: Student[]) => {
      this.students = result;
    });
    this.getGroups();
  }

  goTo(route) {
    this.router.navigate([`${route}/${this.courseId}`]);
  }
  openModal() {
    const dialogRef = this.dialog.open(GradeCategoryModalComponentComponent, {
      width: '390px',
      height: '390px',
      data: { courseId: this.courseId }
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  getGroups() {
    this.groupService.getProfGroups(this.user.id).subscribe(x => this.groups = x)
  }

  filterStudents(group) {
    this.filteredStudents = this.students.filter(x => x.groupId == group.id);
  }
}
