import { Component, OnInit, HostBinding } from '@angular/core';
import { ProfService } from 'src/app/services/prof-service.service';
import { Professor } from 'src/app/models/professor';

@Component({
  selector: 'app-professors',
  templateUrl: './professors.component.html',
  styleUrls: ['./professors.component.scss']
})
export class ProfessorsComponent implements OnInit {

  @HostBinding('class') classes = "container";
  profs: Professor[];

  constructor(private profService: ProfService) { }

  getProfs() {
    this.profService.getAll().subscribe(response => {
      this.profs = response;
    })
  }

  ngOnInit() {
    this.getProfs();
  }

}
