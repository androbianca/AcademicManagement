import { Injectable, Optional } from '@angular/core';
import { BaseService } from './base-service.service';
import { FileModel } from '../models/file';
import { Opt } from '../models/optional';

@Injectable({
    providedIn: 'root'
})
export class OptionalService {

    constructor(private baseService: BaseService) { }

    postFile(optional:Opt) {
        let formData: FormData = new FormData();
        formData.append('file', optional.file);
        formData.append( optional.googleForm, optional.googleForm);
        formData.append(optional.year.toString(), optional.year.toString());
        return this.baseService.postFile(`optionals/upload`, formData);
    }

    delete(itemId:string) {
        return this.baseService.delete(`optionals/${itemId}`);
    }

    getAll() {
        return this.baseService.get(`optionals`);
    }

}
