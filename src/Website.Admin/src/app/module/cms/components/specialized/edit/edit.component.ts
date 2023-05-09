import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { SpecializedOutputModel } from 'src/app/module/shared/model/specialized.model';
import { SpecializedService } from 'src/app/module/shared/service/specialized.service';

@Component({
  selector: 'app-specialized-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class SpecializedEditComponent implements OnInit {

  @Input('id') id:number = 0;
  @Output('onSave') onSave = new EventEmitter<any>();
  form!:FormGroup;
  title!:string;

  constructor(
    private readonly specializedService:SpecializedService,
    private readonly messageService:MessageService
  ) {
  }
  
  ngOnInit(): void {
    this.getById(this.id);
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
    const input = SpecializedOutputModel.fromJS(this.form?.value);
    const $api = input.id == 0 ? this.specializedService.create(input) : this.specializedService.update(input);
    return $api.subscribe(res => {
      this.messageService.add({severity:'success', summary: 'Lưu thành công', life: 1000});
    });
  }

  private getById(id:number){
    if(id != 0){
      this.title = 'Sửa lĩnh vực';
      this.specializedService.getById(id).subscribe(res => {
        this.buildForm(res);
      })
    }
    else{
      this.title = 'Thêm lĩnh vực';
      this.buildForm();
    }
  }

  private buildForm(data?:SpecializedOutputModel | undefined){
    this.form = new FormGroup({
      id: new FormControl(data ? data.id : 0, Validators.required),
      name: new FormControl(data ? data.name : null, Validators.required),
    });
  }

}
