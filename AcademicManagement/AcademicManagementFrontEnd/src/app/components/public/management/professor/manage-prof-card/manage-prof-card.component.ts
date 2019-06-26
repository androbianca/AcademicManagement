import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CourseRead } from 'src/app/models/course-read';
import { CourseService } from 'src/app/services/course-service.service';
import { ProfService } from 'src/app/services/prof-service.service';
import { ProfStudService } from 'src/app/services/prof-stud-service.service';
import { Professor } from 'src/app/models/professor';
import { ProfStud } from 'src/app/models/prof-studs';
import { GroupService } from 'src/app/services/group-service.service';

@Component({
  selector: 'app-manage-prof-card',
  templateUrl: './manage-prof-card.component.html',
  styleUrls: ['./manage-prof-card.component.scss']
})
export class ManageProfCardComponent implements OnInit {
 
  @Input() item: Professor;

  courses = new Array<any>();
  updateProfForm: FormGroup;
  open = false;
  selected = false;
  selectedCourses = new Array<string>();
  profStuds:ProfStud[];


  constructor(private courseService: CourseService,
    private profService:ProfService,
    private groupService: GroupService,
    private profStudService:ProfStudService) { }

  ngOnInit() {
    this.updateProfForm = new FormGroup({
      firstName: new FormControl(this.item.firstName),
      lastName: new FormControl(this.item.lastName),
    });
    this.getProfStuds();
  }

  getProfStuds() {
    this.profStudService.getByProfId(this.item.id).subscribe(response => {
      this.profStuds = response;
      this.getCourses();
    })
  }

  getCourses(){
    this.profStuds.forEach(x=> {
    this.groupService.getById(x.groupId).subscribe(group => {
      this.courseService.getById(x.courseId).subscribe(course => {
        this.courses.push({'id': x.id, 'group':group, 'course': course,'selected':false})
      }) })
    })
  }

  toggle() {
    this.open = !this.open;
  }

  select(course){
    course.selected=!course.selected;
    course.selected ? this.selectedCourses.push(course.id) : this.selectedCourses = this.selectedCourses.filter(x => x != course.id)
}

submit(form){
   this.item.firstName = form.value.firstName;
   this.item.lastName = form.value.lastName;
   this.profService.update(this.item).subscribe(()=>{});
   this.selectedCourses.forEach(x => {
   this.profStudService.delete(x).subscribe(()=>{});
   })
}
}
