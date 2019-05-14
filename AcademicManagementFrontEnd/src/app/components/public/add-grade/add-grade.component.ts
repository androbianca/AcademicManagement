import { Component, OnInit, HostBinding, Input, ɵConsole, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { Grade } from 'src/app/models/grade';
import { GradeService } from 'src/app/services/grade-service.service';
import { SignalRService } from 'src/app/services/signalR-service.service';

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

  newGrade:Grade;
  user: UserDetails;
  grade = new Grade();

  gradesForm = new FormGroup({
    category: new FormControl('',Validators.required),
    value: new FormControl('',Validators.required)
  });

  constructor(private currentUser: CurrentUserDetailsService, private gradeService :GradeService, private signalRService:SignalRService) {
    this.user = this.currentUser.getUser();
    this.grade.profId = this.user.id;
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
    this.signalRService.startConnection();
    this.signalRService.addTransferChartDataListener();   
    this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.signalRService.get()
      .subscribe(res => {
        console.log(res);
      })
  }
}
