import { Component, OnInit, HostBinding } from '@angular/core';
import { ProfService } from 'src/app/services/prof-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Professor } from 'src/app/models/professor';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { MatDialog } from '@angular/material/dialog';
import { CategoriesModalComponent } from 'src/app/components/public/grade-categories/categories-modal/categories-modal.component';

@Component({
  selector: 'app-course-profile',
  templateUrl: './course-profile.component.html',
  styleUrls: ['./course-profile.component.scss']
})
export class CourseProfileComponent implements OnInit {

  @HostBinding('class') classes = 'page-wrapper';
  profs: Professor[];
  courseId: string;
  user: UserDetails;

  constructor(public dialog: MatDialog,
    private profService: ProfService,
    private route: ActivatedRoute,
    private router: Router,
    private currentUserService: CurrentUserDetailsService) {
    this.user = this.currentUserService.getUser();
  }

  ngOnInit() {
    this.getProfs();
  }

  goTo(route) {
    this.router.navigate([`${route}/${this.courseId}`]);
  }

  getProfs() {
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
    });
    this.profService.getByCourseId(this.courseId).subscribe(response => {
      this.profs = response
    })
  }

  
  openDialog(): void {
    const dialogRef = this.dialog.open(CategoriesModalComponent, {
      width: '400px',
      height: '450px',
      data: { courseId: this.courseId }
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }
}

