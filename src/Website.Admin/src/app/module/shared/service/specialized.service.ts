import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SpecializedInputModel, SpecializedOutputModel } from '../model/specialized.model';
import { BasePageInputModel, BasePageOutputModel } from '../model/base.model';

const _prefix = `${environment.coreServerURL}/api`;

@Injectable({
  providedIn: 'root'
})
export class SpecializedService {

  constructor(
    private httpClient: HttpClient,
  ) { }

  getList(input:BasePageInputModel): Observable<BasePageOutputModel<SpecializedOutputModel>> {
    return this.httpClient.get(`${_prefix}/specialized`, input as any).pipe(
        map((m:any) => {
          return {
            totalItem: m.totalItem,
            items: m.items as SpecializedOutputModel[]
          }
        }));
  }

  getById(id:Number) : Observable<SpecializedOutputModel>{
    return this.httpClient.get(`${_prefix}/specialized/${id}`).pipe(
      map(m => {
        return SpecializedOutputModel.fromJS(m);
      })
    );
  }

  create(input:SpecializedInputModel): Observable<Object>{
    return this.httpClient.post(`${_prefix}/specialized`, input);
  }

  update(input:SpecializedInputModel){
    return this.httpClient.put(`${_prefix}/specialized`, input);
  }

  delete(id:number){
    return this.httpClient.delete(`${_prefix}/specialized/${id}`);
  }
}
