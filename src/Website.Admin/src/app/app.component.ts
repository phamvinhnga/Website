import { Component } from '@angular/core';
import { SeoSocialShareData } from './module/shared/model/seo.model';
import { PostService } from './module/shared/service/post.service';
import { SeoService } from './module/shared/service/seo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'my_project';
  constructor(
    private readonly postService:PostService,
    private readonly seoService:SeoService
  ) {
  }

  ngOnInit(): void {
  }
}
