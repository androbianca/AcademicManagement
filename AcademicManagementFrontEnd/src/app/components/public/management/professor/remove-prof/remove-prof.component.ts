import { Component, OnInit, ɵConsole } from '@angular/core';
import { ProfService } from 'src/app/services/prof-service.service';
import { FormGroup, FormControl } from '@angular/forms';
import { PotentialUserService } from 'src/app/services/potentialuser-service.service';
import { Professor } from 'src/app/models/professor';

@Component({
  selector: 'app-remove-prof',
  templateUrl: './remove-prof.component.html',
  styleUrls: ['./remove-prof.component.scss']
})
export class RemoveProfComponent implements OnInit {

  profs:Professor[];
  removeProfForm = new FormGroup({
    prof: new FormControl(''),
  });

  constructor(private profService: ProfService,
    private potentialUserService: PotentialUserService) { }

  ngOnInit() {
    this.getProfs();
  }

  getProfs(){
  this.profService.getAll().subscribe(response => {
    this.profs = response;
  })
  }

  removePotentialUser() {
    var potentialUserId = this.removeProfForm.get('prof').value.potentialUserId;
    this.potentialUserService.remove(potentialUserId).subscribe(reponse=> {
      
    })
  }

  submit(form) {
    var profId = form.value.prof.id
    this.profService.remove(profId).subscribe(() => console.log("user deleted"));
  }

}
