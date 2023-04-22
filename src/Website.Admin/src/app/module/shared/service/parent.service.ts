import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ParentInputModel, ParentOutputModel } from '../model/parent.model';
import { BasePageInputModel, BasePageOutputModel } from '../model/base.model';

const _prefix = `${environment.coreServerURL}/api`;

@Injectable({
  providedIn: 'root'
})
export class ParentService {

  constructor(
    private httpClient: HttpClient,
  ) { }


  updateDisplayIndexPage(id:number, isDisplayIndexPage:boolean){
    return this.httpClient.put(`${_prefix}/parent/index-page/${id}?isDisplayIndexPage=${isDisplayIndexPage}`,null);
  }

  getList(input:BasePageInputModel): Observable<BasePageOutputModel<ParentOutputModel>> {
    return this.httpClient.get(`${_prefix}/parent`, input as any).pipe(
        map((m:any) => {
          return {
            totalItem: m.totalItem,
            items: m.items as ParentOutputModel[]
          }
        }));
  }

  getById(id:Number) : Observable<ParentOutputModel>{
    return this.httpClient.get(`${_prefix}/parent/${id}`).pipe(
      map(m => {
        return ParentOutputModel.fromJS(m);
      })
    );
  }

  create(input:ParentInputModel): Observable<Object>{
    return this.httpClient.post(`${_prefix}/parent`, input);
  }

  update(input:ParentInputModel){
    return this.httpClient.put(`${_prefix}/parent`, input);
  }

  delete(id:number){
    return this.httpClient.delete(`${_prefix}/parent/${id}`);
  }
}
