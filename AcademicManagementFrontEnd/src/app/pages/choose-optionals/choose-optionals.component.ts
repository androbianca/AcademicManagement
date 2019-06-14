import { Component, OnInit } from '@angular/core';
import { OptionalService } from 'src/app/services/optional.service';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { Role } from 'src/app/models/role-enum';

@Component({
  selector: 'app-choose-optionals',
  templateUrl: './choose-optionals.component.html',
  styleUrls: ['./choose-optionals.component.scss']
})
export class ChooseOptionalsComponent implements OnInit {

  link: string;
  resource = new Array<any>();
  files: any;
  user:UserDetails;
  isAdmin:boolean;
  role: typeof Role = Role;


  constructor(private http: OptionalService, private currentUser:CurrentUserDetailsService) {
    this.user = this.currentUser.getUser();
    this.isAdmin = this.user.userRole == this.role.admin ? true : false;

  }

  ngOnInit() {
    this.loadFiles();
  }

  loadFiles() {
    this.http.getAll().subscribe(response => {
      this.files = response;
      this.files.forEach(element => {
        this.resource.push({id:element.id, year: element.year, googleForm:element.googleForm,filename: element.filename, link: `../../../../assets/files/${element.id}/${element.filename}` })
      })
    });
  }

  delete(id){
    this.http.delete(id).subscribe(x=> console.log(x));
  }

}
