import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CmsComponent } from './cms.component';
import { PostEditComponent } from './components/post/edit/edit.component';
import { PostComponent } from './components/post/post.component';
import { ParentComponent } from './components/parent/parent.component';
import { ParentEditComponent } from './components/parent/edit/edit.component';
import { SpecializedComponent } from './components/specialized/specialized.component';

const routes: Routes = [
  {
    path: '',
    component: CmsComponent,
    children: [
      {
        path: 'post/:type',
        component: PostComponent,
      },
      {
        path: 'post/:type/:id',
        component: PostEditComponent
      },
      {
        path: 'parent',
        component: ParentComponent
      },
      {
        path: 'parent/:id',
        component: ParentEditComponent
      },
      {
        path: 'specialized',
        component: SpecializedComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CmsRoutingModule { }
