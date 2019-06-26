import { Component, OnInit, HostBinding } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CurrentUserDetailsService } from 'src/app/services/current-user-details.service';
import { UserDetails } from 'src/app/models/userDetails';
import { Role } from 'src/app/models/role-enum';
import { FileModel } from 'src/app/models/file';
import { FileService } from 'src/app/services/file-upload.service';
import { Resource } from 'src/app/components/public/files/file-download/file-download.component';

@Component({
  selector: 'app-resources',
  templateUrl: './resources.component.html',
  styleUrls: ['./resources.component.scss']
})
export class ResourcesComponent implements OnInit {

  @HostBinding('class') classes = 'page-wrapper';
  courseId: string;
  user:UserDetails;
  role : typeof Role = Role;
  isStudent:boolean;
  hasResources = false;
  files: FileModel[];
  resources = new Array<Resource>();

  
  constructor(private route: ActivatedRoute,
    private http: FileService,
    private currentUser:CurrentUserDetailsService) {
      this.user = this.currentUser.getUser();
      this.isStudent = this.user.userRole == this.role.student ? true : false;
     }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.courseId = params['courseId'];
    });
    this.loadFiles();

  }

  loadFiles() {
    this.http.getByCourseId(this.courseId).subscribe(response => {
      this.files = response;
      console.log(response);
      this.hasResources = this.files.length <= 0 ? false : true;
      this.files.forEach(element => {
        this.resources.push({ file: element, link: `../../../../assets/files/${this.courseId}/${element.fileName}` })
      })
      this.resources == this.resources.sort((val1, val2) => {
       if(val1 > val2)
       {
         return 1;
       }
       else return -1
      })
    });
  }
}
