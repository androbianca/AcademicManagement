import { Component, OnInit, HostBinding } from '@angular/core';
import { StudentService } from 'src/app/services/student-service.service';
import { Student } from 'src/app/models/student';
import { GroupService } from 'src/app/services/group-service.service';
import { GroupRead } from 'src/app/models/groupRead';
import { StudCourseService } from 'src/app/services/stud-course-service.service';

@Component({
  selector: 'app-update-stud',
  templateUrl: './update-stud.component.html',
  styleUrls: ['./update-stud.component.scss']
})
export class UpdateStudComponent implements OnInit {

  @HostBinding('class') classes = 'wrapper';

  students = new Array<Student>();
  groups = new Array<GroupRead>();
  obj = new Array<any>();
  constructor(private studService: StudentService,
    private groupService: GroupService,

    ) { }

  ngOnInit() {
    this.getStudents();
  }

  getStudents() {
    this.studService.getAll().subscribe(x => {
      this.students = x;
      this.getCurrentGroup();

    })
  }


getCurrentGroup(){
    this.students.forEach(x=> {
      this.groupService.getById(x.groupId).subscribe(group => {
        this.obj.push({'group':group,'stud':x})
      })
    })
  
}
}
