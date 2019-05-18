import { Component, OnInit, HostBinding, Input, ɵConsole, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { Grade } from 'src/app/models/grade';
import { GradeService } from 'src/app/services/grade-service.service';
import { SignalRService } from 'src/app/services/signalR-service.service';
import { NotificationService } from 'src/app/services/notification-service.service';
import { Notif } from 'src/app/models/notification';

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

  notification = new Notif();
  newGrade:Grade;
  user: UserDetails;
  grade = new Grade();
  isDisabled = true;

  gradesForm = new FormGroup({
    category: new FormControl('',Validators.required),
    value: new FormControl('',Validators.required)
  });

  constructor(private currentUser: CurrentUserDetailsService, 
    private gradeService :GradeService, 
    private notificationService:NotificationService) {
    this.user = this.currentUser.getUser();
    this.grade.profId = this.user.id;
  }

  onChanges(): void {
    this.gradesForm.valueChanges.subscribe(x=> {
      console.log(this.isDisabled)
    this.isDisabled = this.gradesForm.valid ? false :true;
    })
  }

  addNotification(){
    this.notification.title = "aa";
    this.notification.body = "bb";
    this.notification.userId = this.studentId;
    this.notificationService.add(this.notification).subscribe(response=>console.log(response))
  }

  save(gradesForm) {
    this.grade.courseId = this.courseId;
    this.grade.studentId = this.studentId;
    this.grade.value = gradesForm.value.value;
    this.grade.category = gradesForm.value.category;

    this.newGrade = Object.assign({}, this.grade);
    this.gradesListChanged.emit(this.newGrade);
  }

  ngOnInit(): void {
    this.onChanges();
  }

}
