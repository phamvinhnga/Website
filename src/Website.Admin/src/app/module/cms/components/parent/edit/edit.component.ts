import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as _ from 'lodash';
import { MessageService } from 'primeng/api';
import { BaseComponent } from 'src/app/module/shared/model/base.component.model';
import { FileModel } from 'src/app/module/shared/model/file.model';
import { ParentOutputModel } from 'src/app/module/shared/model/parent.model';
import { ParentService } from 'src/app/module/shared/service/parent.service';
import { environment } from 'src/environments/environment';
const _websiteURL = `${environment.websiteURL}`;

@Component({
  selector: 'app-parent-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class ParentEditComponent extends BaseComponent implements OnInit {

  displayBasic = false;
  constructor(
    private readonly parentService:ParentService,
    private readonly router:Router,
    private readonly activatedRoute: ActivatedRoute,
    private readonly messageService:MessageService
  ) {
    super();
  }

  ngOnInit(): void {
    const id = Number(this.activatedRoute.snapshot.params['id'] || 0);
    this.getById(id);
  }

  get thumbnail() : FileModel | undefined{
    if(!this.form || !this.form.controls['thumbnail'].value){
      return undefined;
    }
    return this.form.controls['thumbnail'].value;
  }

  formValidation(key:string) : boolean{
    if(!this.form || !this.form.controls[key]){
      return false;
    }
    return this.form.controls[key].errors && this.form.controls[key].touched ? true : false;
  }

  save(){
    if(this.form?.invalid){
      return;
    }
    const input = ParentOutputModel.fromJS(this.form?.value);
    input.thumbnail = this.listFileImage.length > 0 ? this.listFileImage[0] : undefined;
    const $api = input.id == 0 ? this.parentService.create(input) : this.parentService.update(input);
    return $api.subscribe(res => {
      this.messageService.add({severity:'success', summary: 'Lưu thành công', life: 1000});
      this.router.navigateByUrl('cms/parent');
    });
  }

  private getById(id:number){
    if(id != 0){
      this.title = 'Sửa phụ huynh';
      this.parentService.getById(id).subscribe(res => {
        this.buildForm(res);
      })
    }
    else{
      this.title = 'Thêm phụ huynh';
      this.buildForm();
    }
  }

  private buildForm(data?:ParentOutputModel | undefined){
    this.form = new FormGroup({
      id: new FormControl(data ? data.id : 0, Validators.required),
      name: new FormControl(data ? data.name : null, Validators.required),
      surname: new FormControl(data ? data.surname : null, Validators.required),
      feedback: new FormControl(data ? data.feedback : null),
      profession: new FormControl(data ? data.profession : null),
      index: new FormControl(data ? data.index : 1, Validators.required),
      isDisplayIndexPage: new FormControl(data ? data.isDisplayIndexPage : false),
    });
    if(data?.thumbnail){
      this.listFileImage.push(data.thumbnail);
    }
  }
}
