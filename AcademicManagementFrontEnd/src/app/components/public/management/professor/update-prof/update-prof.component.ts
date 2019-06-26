import { Component, OnInit, HostBinding } from '@angular/core';
import { ProfService } from 'src/app/services/prof-service.service';
import { Professor } from 'src/app/models/professor';

@Component({
  selector: 'app-update-prof',
  templateUrl: './update-prof.component.html',
  styleUrls: ['./update-prof.component.scss']
})
export class UpdateProfComponent implements OnInit {

  @HostBinding('class') classes = 'wrapper';

  profs : Professor[];
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
