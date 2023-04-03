import { Component, OnInit } from '@angular/core';
import { Meta } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService, MessageService, Message } from 'primeng/api';
import { BaseComponent } from 'src/app/module/shared/model/base.component.model';
import { BasePageInputModel, BasePageOutputModel } from 'src/app/module/shared/model/base.model';
import { PostOutputModel } from 'src/app/module/shared/model/post.model';
import { PostService } from 'src/app/module/shared/service/post.service';
@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
  providers: [PostService]
})
export class PostComponent extends BaseComponent implements OnInit {

  typePost:any;
  data!: BasePageOutputModel<PostOutputModel>;
  filterPage: BasePageInputModel = new BasePageInputModel();
  search:string = '';
  constructor(
    private readonly confirmationService:ConfirmationService,
    private readonly messageService:MessageService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly postService:PostService,
    private readonly meta:Meta
    ) {
    super();
  }

  ngOnInit() {
    this.typePost = this.activatedRoute.snapshot.params['type'] || undefined;
    this.filterPage.maxCountResult = 9999;
    this.getList();
  }

  onDelete(data:PostOutputModel) {
    if(!data){
      return;
    }
    this.confirmationService.confirm({
        message: `Bạn có chắc chắn xóa bài viết ${data.title}?`,
        header: 'Xóa bài viết',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.postService.delete(data.id).subscribe(res => {
            this.getList();
            this.messageService.add({severity:'warn', summary: 'Xóa thành công', life: 1000});
          })
        }
    });
  }

  private getList(){
    this.postService.getList(this.filterPage).subscribe(res => {
      this.data = res;
    })
  }
}
