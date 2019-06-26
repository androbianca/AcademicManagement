import { Component, OnInit, Input } from '@angular/core';
import { StudCourse } from 'src/app/models/stud-course';
import { Student } from 'src/app/models/student';
import { FormGroup, FormControl } from '@angular/forms';
import { GroupRead } from 'src/app/models/groupRead';
import { StudentService } from 'src/app/services/student-service.service';
import { StudCourseService } from 'src/app/services/stud-course-service.service';
import { CourseRead } from 'src/app/models/course-read';
import { CourseService } from 'src/app/services/course-service.service';
import { GroupService } from 'src/app/services/group-service.service';

@Component({
  selector: 'app-manage-stud-card',
  templateUrl: './manage-stud-card.component.html',
  styleUrls: ['./manage-stud-card.component.scss']
})
export class ManageStudCardComponent implements OnInit {

  @Input() item: any;

  selected = false;
  updateStudForm: FormGroup;
  open = false;
  currentGroup: GroupRead;
  courses = new Array<any>();
  selectedCourses = new Array<string>();
  groups:GroupRead[];

  constructor(private studentService: StudentService,
    private groupService: GroupService,
    private courseSwrvice: CourseService,
    private studCourse: StudCourseService) { }

  ngOnInit() {
    console.log(this.item)
      this.updateStudForm = new FormGroup({
        firstName: new FormControl(this.item.stud.firstName),
        lastName: new FormControl(this.item.stud.lastName),
        group: new FormControl(this.item.group)
      });

      this.getGroups();
      this.getOptionalCourses();

  }

  getGroups() {
    this.groupService.getAll().subscribe(response => {
      this.groups = response.filter(x=> x.isDeleted == false);
    })
  }

  toggle() {
    this.open = !this.open;
  }

  submit(form) {
    debugger
    this.item.stud.firstName = form.value.firstName;
    this.item.stud.lastName = form.value.lastName;
    this.item.stud.groupId = form.value.group.id;
    this.studentService.update(this.item.stud).subscribe(() => { });
    this.selectedCourses.forEach(x => {
      console.log(x)
      this.studCourse.delete(x).subscribe(()=> {
        console.log('succ');
      })
    })
  }

  select(course){
    course.selected=!course.selected;
    course.selected ? this.selectedCourses.push(course.id) : this.selectedCourses = this.selectedCourses.filter(x => x != course.id)
}

  getOptionalCourses() {
    this.studCourse.getByStudentId(this.item.stud.id).subscribe(studCourses => {
      studCourses.forEach(element => {
        var id = element.id;
        this.courseSwrvice.getById(element.courseId).subscribe(x => {
         this.courses.push({'id':id , 'course': x ,'selected':false})
        })

      })
    })

  }
}
