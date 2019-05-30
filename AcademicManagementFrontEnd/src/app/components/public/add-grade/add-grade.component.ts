import { Component, OnInit, HostBinding, Input, ɵConsole, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { Grade } from 'src/app/models/grade';
import { GradeService } from 'src/app/services/grade-service.service';
import { SignalRService } from 'src/app/services/signalR-service.service';
import { NotificationService } from 'src/app/services/notification-service.service';
import { Notif } from 'src/app/models/notification';
import { GradeCategoryService } from 'src/app/services/grade-category.service';
import { GradeCategory } from 'src/app/models/grade-category';

@Component({
  selector: 'app-add-grade',
  templateUrl: './add-grade.component.html',
  styleUrls: ['./add-grade.component.scss']
})
export class AddGradeComponent implements OnInit{

  @Input() studentId : string;
  @Input() courseId : string;

  @Output() gradesListChanged : EventEmitter<any> = new EventEmitter();
  @HostBinding('class') classes = 'add-grade-card';

  numbersRegex = '^[0-9]*$';
  notification = new Notif();
  newGrade:Grade;
  user: UserDetails;
  grade = new Grade();
  isDisabled = true;
  errorMessage= 'This fied id required!';
  categories:GradeCategory[];
  gradesForm = new FormGroup({
    category: new FormControl('',Validators.required),
    value: new FormControl('',[Validators.required,Validators.pattern('^[0-9]*$')])
  });

  constructor(private currentUser: CurrentUserDetailsService, 
    private gradeService :GradeService, 
    private notificationService:NotificationService,
    private gradeCategoryService:GradeCategoryService) {
    this.user = this.currentUser.getUser();
    this.grade.profId = this.user.id;
  }

  onChanges(): void {
    this.gradesForm.valueChanges.subscribe(x=> {
      var errors = this.gradesForm.get('value').hasError('pattern');
      this.errorMessage = errors ? 'The input should be a number' : 'This fied is required!';
      this.isDisabled = this.gradesForm.valid ? false :true;
    })
  }

  addNotification(){
    this.notification.title = "aa";
    this.notification.body = "bb";
    this.notification.userId = this.studentId;
    this.notificationService.add(this.notification).subscribe(response=>
      {})
  }

  save(gradesForm) {
    this.grade.courseId = this.courseId;
    this.grade.studentId = this.studentId;
    this.grade.value = gradesForm.value.value;
    this.grade.categoryId = gradesForm.value.category.id;
    this.grade.category = gradesForm.value.category.name;

    this.newGrade = Object.assign({}, this.grade);
    this.gradesListChanged.emit(this.newGrade);
  }

  ngOnInit(): void {
    this.onChanges();
    this.getCategories();
  }

  getCategories(){
    this.gradeCategoryService.getByCourseId(this.courseId).subscribe(x=> {
      this.categories =x;
    })
  }

}
