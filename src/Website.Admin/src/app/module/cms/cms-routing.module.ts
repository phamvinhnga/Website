import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CmsComponent } from './cms.component';
import { PostEditComponent } from './components/post/edit/edit.component';
import { PostComponent } from './components/post/post.component';

const routes: Routes = [
  {
    path: '',
    component: CmsComponent,
    children: [
      {
        path: 'post',
        component: PostComponent,
      },
      {
        path: 'post/:id',
        component: PostEditComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CmsRoutingModule { }
