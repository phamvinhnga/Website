import { Component, OnInit } from '@angular/core';
import { Meta } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { BasePageOutputModel, BasePageInputModel } from 'src/app/module/shared/model/base.model';
import { SpecializedOutputModel } from 'src/app/module/shared/model/specialized.model';
import { SpecializedService } from 'src/app/module/shared/service/specialized.service';
import { DialogService, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { SpecializedEditComponent } from './edit/edit.component';

@Component({
  selector: 'app-specialized',
  templateUrl: './specialized.component.html',
  styleUrls: ['./specialized.component.scss']
})
export class SpecializedComponent implements OnInit {

  data!: BasePageOutputModel<SpecializedOutputModel>;
  filterPage: BasePageInputModel = new BasePageInputModel();
  displayEditForm:boolean = false;

  constructor(
    private readonly confirmationService:ConfirmationService,
    private readonly messageService:MessageService,
    private readonly specializedService:SpecializedService,
    private readonly dialogService: DialogService
    ) {
  }

  ngOnInit() {
    this.filterPage.maxCountResult = 9999;
    this.getList();
  }

  onDelete(data:SpecializedOutputModel) {
    if(!data){
      return;
    }
    this.confirmationService.confirm({
        message: `Bạn có chắc chắn xóa lĩnh vực ${data.name}?`,
        header: 'Xóa phụ huynh',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.specializedService.delete(data.id).subscribe(res => {
            this.getList();
            this.messageService.add({severity:'warn', summary: 'Xóa thành công', life: 1000});
          })
        }
    });
  }

  private getList(){
    this.specializedService.getList(this.filterPage).subscribe(res => {
      this.data = res;
    })
  }

  openDialog(data:SpecializedOutputModel | null){
    const modal = this.dialogService.open(SpecializedEditComponent, ({
      header: data ? 'Sửa lĩnh vực' : 'Thêm lĩnh vực',
      width: '35vh',
      data: data ? data.id : 0,
    } as DynamicDialogConfig));
  }
}
