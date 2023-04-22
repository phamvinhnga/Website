import { Component, OnInit } from '@angular/core';
import { Meta } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { BasePageOutputModel, BasePageInputModel } from 'src/app/module/shared/model/base.model';
import { ParentOutputModel } from 'src/app/module/shared/model/parent.model';
import { ParentService } from 'src/app/module/shared/service/parent.service';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.scss']
})
export class ParentComponent implements OnInit {

  typeParent:any;
  data!: BasePageOutputModel<ParentOutputModel>;
  filterPage: BasePageInputModel = new BasePageInputModel();
  search:string = '';
  constructor(
    private readonly confirmationService:ConfirmationService,
    private readonly messageService:MessageService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly parentService:ParentService,
    private readonly meta:Meta
    ) {
  }

  ngOnInit() {
    this.typeParent = this.activatedRoute.snapshot.params['type'] || undefined;
    this.filterPage.maxCountResult = 9999;
    this.getList();
  }

  changeDisplayIndexPage(data:ParentOutputModel){
    if(!data){
      return;
    }
    this.parentService.updateDisplayIndexPage(data.id, data.isDisplayIndexPage).subscribe(res => {})
  }

  onDelete(data:ParentOutputModel) {
    if(!data){
      return;
    }
    this.confirmationService.confirm({
        message: `Bạn có chắc chắn xóa phụ huynh ${data.fullName}?`,
        header: 'Xóa phụ huynh',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.parentService.delete(data.id).subscribe(res => {
            this.getList();
            this.messageService.add({severity:'warn', summary: 'Xóa thành công', life: 1000});
          })
        }
    });
  }

  private getList(){
    this.parentService.getList(this.filterPage).subscribe(res => {
      this.data = res;
    })
  }

}
