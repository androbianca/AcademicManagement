import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { CourseService } from 'src/app/services/course-service.service';
import { CourseRead } from 'src/app/models/course-read';
import { GroupService } from 'src/app/services/group-service.service';
import { Professor } from 'src/app/models/professor';
import { ProfService } from 'src/app/services/prof-service.service';
import { PotentialUserService } from 'src/app/services/potentialuser-service.service';
import { ProfStudService } from 'src/app/services/prof-stud-service.service';
import { ProfStud } from 'src/app/models/prof-studs';
import { GroupRead } from 'src/app/models/groupRead';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserRoleService } from 'src/app/services/user-role.service';
import { PotentialUser } from 'src/app/models/potential-user';

@Component({
  selector: 'app-add-prof',
  templateUrl: './add-prof.component.html',
  styleUrls: ['./add-prof.component.scss']
})
export class AddProfComponent implements OnInit {

  profId: any;
  profStud = new ProfStud();
  courses: CourseRead[];
  groups: GroupRead[];
  allgroups: GroupRead[];
  prof = new Professor();
  isDisabled: boolean = true;
  roleId: string;
  potentialUser = new PotentialUser();
  count = 1;
  errorMessage = "This field is required!";
  forms = [{ course: 'course1', group: 'group1' }];

  addProfForm = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    userCode: new FormControl('', Validators.required),
    course1: new FormControl('', Validators.required),
    group1: new FormControl('', Validators.required)
  });

  constructor(private courseService: CourseService,
    private groupService: GroupService,
    private profService: ProfService,
    private snackBar: MatSnackBar,
    private userRoleService: UserRoleService,
    private potentialUserService: PotentialUserService,
    private profStudService: ProfStudService) { }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  onChanges() {
    this.addProfForm.valueChanges.subscribe(() => {
      if (this.addProfForm.valid) {
        this.isDisabled = false;
      }
    })
  }

  ngOnInit() {
    this.getCourses();
    this.getGroups();
    this.onChanges();

  }

  getCourses() {
    this.courseService.getAll().subscribe(result =>
      this.courses = result.filter(x => x.isDeleted == false))
  }

  getGroups() {
    this.groupService.getAll().subscribe(result => {
      this.groups = result.filter(x => x.isDeleted == false)
      this.allgroups = this.groups
    }
    )
  }

  filterGroups(course) {
    this.groups = this.allgroups.filter(x => x.year === course.year)
  }

  add() {
    var course = new FormControl('');
    var group = new FormControl('');
    this.count++;
    var cname = 'course' + this.count;
    var gname = 'group' + this.count;
    this.forms.push({ course: cname, group: gname })

    this.addProfForm.addControl(cname, course);
    this.addProfForm.addControl(gname, group);
  }

  getRoleId() {
    this.userRoleService.getProfRoleId().subscribe(result => {
      this.roleId = result.id;
      this.addPotentialUser();

    })
  }

  addPotentialUser() {
    this.potentialUser.userCode = this.addProfForm.value.userCode;
    this.potentialUser.firstName = this.addProfForm.value.firstName;
    this.potentialUser.lastName = this.addProfForm.value.lastName;
    this.potentialUser.roleId = this.roleId;
    this.potentialUserService.addPotentialUser(this.potentialUser).subscribe(response => {
      this.prof.potentialUserId = response.id
      this.addProfessor();
    });
  }

  addProfessor() {
    this.profService.addProf(this.prof).subscribe((result: Professor) => {
      this.addProfStud(result.id)
    },
      error => {
      });
  }

  submit(form) {
    if (form.valid) {

      this.prof.firstName = form.value.firstName;
      this.prof.lastName = form.value.lastName;
      this.prof.userCode = form.value.userCode;
      this.getRoleId();
    }
  }

  addProfStud(profId) {
    var profStuds = new Array<ProfStud>();
    this.forms.forEach(el => {
      var profStud = Object.assign({}, new ProfStud());
      profStud.courseId = this.addProfForm.get(el.course).value.id;
      profStud.groupId = this.addProfForm.get(el.group).value.id;
      profStud.profId = profId;
      profStuds.push(profStud);
    })

    this.profStudService.addProfStuds(profStuds).subscribe(response => {
      this.snackBar.open('success')
    }, err => {
      this.snackBar.open('fail')
    });
  }

}
