import { Component, OnInit, Input, HostBinding } from '@angular/core';
import { Professor } from 'src/app/models/professor';
import { Router } from '@angular/router';

@Component({
  selector: 'app-prof-card',
  templateUrl: './prof-card.component.html',
  styleUrls: ['./prof-card.component.scss']
})
export class ProfCardComponent implements OnInit {

  @Input() prof : Professor;
  @HostBinding('class') classes = 'prof-card';

  name: string;
  initials:string;

  constructor(private router: Router) { }

  ngOnInit() {
    this.getName();
    this.getInitials();
  }

  getName(){
    this.name = this.prof.lastName + ' ' + this.prof.firstName;
  }

  getInitials(){
    this.initials = this.prof.lastName[0] + ' ' + this.prof.firstName[0];
  }

  goTo(){
     this.router.navigate([`professors/${this.prof.id}`]);
  }

}
