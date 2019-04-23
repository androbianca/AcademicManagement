import { Component, OnInit, HostBinding, Input, ɵConsole } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { Grade } from 'src/app/models/grade';
import { GradeService } from 'src/app/services/grade-service.service';

@Component({
  selector: 'app-add-grade',
  templateUrl: './add-grade.component.html',
  styleUrls: ['./add-grade.component.scss']
})
export class AddGradeComponent implements OnInit {

  @Input() studentId : string;
  @Input() courseId : string;
  @HostBinding('class') classes = 'add-grade-card';
  user: UserDetails;
  grade = new Grade();
  gradesForm = new FormGroup({
    category: new FormControl('',Validators.required),
    value: new FormControl('',Validators.required)
  });

  constructor(private currentUser: CurrentUserDetailsService, private gradeService :GradeService) {
    this.user = this.currentUser.getUser();
    this.grade.profId = this.user.id;
  }

  ngOnInit() {}

  save(gradesForm) {
    this.grade.courseId = this.courseId;
    this.grade.studentId = this.studentId;
    this.grade.value = gradesForm.value.value;
    this.grade.category = gradesForm.value.category;

    console.log(this.grade);
    this.gradeService.addGrade(this.grade).subscribe(result =>
    console.log("success"))

  }

}
