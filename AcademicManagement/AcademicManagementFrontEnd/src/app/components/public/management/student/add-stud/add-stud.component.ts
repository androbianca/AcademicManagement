import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CourseService } from 'src/app/services/course-service.service';
import { GroupService } from 'src/app/services/group-service.service';
import { CourseRead } from 'src/app/models/course-read';
import { PotentialUserService } from 'src/app/services/potentialuser-service.service';
import { Student } from 'src/app/models/student';
import { StudentService } from 'src/app/services/student-service.service';
import { StudCourse } from 'src/app/models/stud-course';
import { StudCourseService } from 'src/app/services/stud-course-service.service';
import { GroupRead } from 'src/app/models/groupRead';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserRoleService } from 'src/app/services/user-role.service';
import { PotentialUser } from 'src/app/models/potential-user';


@Component({
  selector: 'app-add-stud',
  templateUrl: './add-stud.component.html',
  styleUrls: ['./add-stud.component.scss']
})
export class AddStudComponent implements OnInit {

  courses: CourseRead[];
  errorMessage = "This field is required!";
  groups: GroupRead[];
  optionals: any;
  student = new Student();
  studId: string;
  isDisabled: boolean = true;
  roleId:string;
  potentialUser= new PotentialUser();

  addStudForm = new FormGroup({
    firstName: new FormControl('',Validators.required),
    lastName: new FormControl('',Validators.required),
    userCode: new FormControl('',Validators.required),
    group: new FormControl('',Validators.required),
  });

  constructor(private courseSrvice: CourseService,
    private groupService: GroupService,
    private potentialUserService: PotentialUserService,
    private studentService: StudentService,
    private snackBar: MatSnackBar,
    private userRoleService:UserRoleService,
    private StudCourseService: StudCourseService) { }


    
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  onChanges() {
    this.addStudForm.valueChanges.subscribe(() => {
      if (this.addStudForm.valid) {
        this.isDisabled = false;
      }
    })
  }

  getGroups() {
    this.groupService.getAll().subscribe(response => {
      this.groups = response.filter(x=> x.isDeleted == false);
    })
  }

  addPotentialUser() {
    this.potentialUser.userCode = this.addStudForm.value.userCode;
    this.potentialUser.firstName = this.addStudForm.value.firstName;
    this.potentialUser.lastName = this.addStudForm.value.lastName;

    this.potentialUserService.addPotentialUser(this.potentialUser).subscribe(response => {
      this.student.potentialUserId = response.id
      this.addStudent();
    });
  }

  addStudent() {
    this.studentService.addStudent(this.student).subscribe(response => {
      this.studId = response.id;
      this.snackBar.open('success')
    }, err => {
     // this.snackBar.open('fail')
    });
    
  }

  getRoleId() {
    this.userRoleService.getStudentRoleId().subscribe(result => {
      this.potentialUser.roleId = result.id;
      this.addPotentialUser();
    })
  }

  submit(form) {
    if(form.valid){
    this.student.firstName = form.value.firstName;
    this.student.lastName = form.value.lastName;
    this.student.userCode = form.value.userCode;
    this.student.groupId = form.value.group.id;
    this.getRoleId();
  }}

  ngOnInit() {
    this.getGroups();
    this.onChanges();

  }
}
