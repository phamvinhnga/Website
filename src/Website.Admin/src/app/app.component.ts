import { Component } from '@angular/core';
import { SeoSocialShareData } from './module/shared/model/seo.model';
import { PostService } from './module/shared/service/post.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(
    private readonly postService:PostService,
  ) {
  }

  ngOnInit(): void {
  }
}
