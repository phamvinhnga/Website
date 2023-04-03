import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BasePageInputModel, BasePageOutputModel } from '../model/base.model';
import { PostInputModel, PostOutputModel } from '../model/post.model';

const _prefix = `${environment.coreServerURL}/api`;

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(
    private httpClient: HttpClient,
  ) { }


  getList(input:BasePageInputModel): Observable<BasePageOutputModel<PostOutputModel>> {
    return this.httpClient.get(`${_prefix}/post`, input as any).pipe(
        map((m:any) => {
          return {
            totalItem: m.totalItem,
            items: m.items as PostOutputModel[]
          }
        }));
  }

  getByPermalink(permalink:string) : Observable<PostOutputModel>{
    return this.httpClient.get(`${_prefix}/post/permalink/${permalink}`).pipe(
      map(m => {
        return PostOutputModel.fromJS(m);
      })
    );
  }

  getById(id:Number) : Observable<PostOutputModel>{
    return this.httpClient.get(`${_prefix}/post/${id}`).pipe(
      map(m => {
        return PostOutputModel.fromJS(m);
      })
    );
  }

  create(input:PostInputModel){
    return this.httpClient.post(`${_prefix}/post`, input);
  }

  update(input:PostInputModel){
    return this.httpClient.put(`${_prefix}/post`, input);
  }

  delete(id:number){
    return this.httpClient.delete(`${_prefix}/post/${id}`);
  }
}
