import { Component, OnInit } from '@angular/core';
import { ProfService } from 'src/app/services/prof-service.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { PotentialUserService } from 'src/app/services/potentialuser-service.service';
import { Professor } from 'src/app/models/professor';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-remove-prof',
  templateUrl: './remove-prof.component.html',
  styleUrls: ['./remove-prof.component.scss']
})
export class RemoveProfComponent implements OnInit {

  profs: Professor[];
  removeProfForm = new FormGroup({
    prof: new FormControl('',Validators.required),
  });
  isDisabled: boolean = true;

  constructor(private profService: ProfService,
    private snackBar: MatSnackBar,
    private potentialUserService: PotentialUserService) { }

  ngOnInit() {
    this.getProfs();;
    this.onChanges()
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
    });
  }

  onChanges() {
    this.removeProfForm.valueChanges.subscribe(() => {
      if (this.removeProfForm.valid) {
        this.isDisabled = false;
      }
    })
  }


  getProfs() {
    this.profService.getAll().subscribe(response => {
      this.profs = response.filter(x=> x.isDeleted == false);
    })
  }

  removePotentialUser() {
    var potentialUserId = this.removeProfForm.get('prof').value.potentialUserId;
    this.potentialUserService.remove(potentialUserId).subscribe(reponse => {
    })
  }

  submit(form) {
    var profId = form.value.prof.id
    this.profService.remove(profId).subscribe(response => {
      this.snackBar.open('success')
    }, err => {
      this.snackBar.open('fail')
    });
  }
  }

