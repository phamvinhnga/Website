import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CmsRoutingModule } from './cms-routing.module';
import { CmsComponent } from './cms.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppLayoutModule } from './layout/app.layout.module';
import { PostComponent } from './components/post/post.component';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { SliderComponent } from './components/slider/slider.component';
import { ManagerAboutUsComponent } from './components/about-us/about-us.component';
import { ManagerMenuComponent } from './components/menu/menu.component';
import { ManagerFooterComponent } from './components/footer/footer.component';
import { ManagerHeaderComponent } from './components/header/header.component';
import { LocaltionComponent } from './components/localtion/localtion.component';
import { ShopComponent } from './components/shop/shop.component';
import { AccountComponent } from './components/account/account.component';
import { AccountInfoComponent } from './components/account-info/account-info.component';
import { FileUploadModule} from 'primeng/fileupload'; 
import { NgxSummernoteModule } from 'ngx-summernote';
import { PostEditComponent } from './components/post/edit/edit.component';
import { InputTextModule } from 'primeng/inputtext';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ToastModule } from 'primeng/toast';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ParentModule } from './components/parent/parent.module';
import { SpecializedModule } from './components/specialized/specialized.module';

@NgModule({
  declarations: [
    CmsComponent,
    PostComponent,
    SliderComponent,
    ManagerAboutUsComponent,
    ManagerMenuComponent,
    ManagerFooterComponent,
    ManagerHeaderComponent,
    LocaltionComponent,
    ShopComponent,
    AccountComponent,
    AccountInfoComponent,
    PostEditComponent
  ],
  imports: [
    ProgressSpinnerModule,
    NgxSummernoteModule,
    FileUploadModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TableModule,
    ButtonModule,
    CmsRoutingModule,
    DialogModule,
    ConfirmDialogModule,
    AppLayoutModule,
    InputTextModule,
    MessagesModule,
    MessageModule,
    ToastModule,
    ParentModule,
    SpecializedModule
  ],
  providers:[
    ConfirmationService,
    MessageService,
  ],
})
export class CmsModule { }
