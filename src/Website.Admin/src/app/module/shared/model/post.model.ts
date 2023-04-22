import { FileModel } from "./file.model";

export class PostInputModel implements IPostInputModel {
  id:number | undefined;
  title:string | undefined;
  type:string | undefined;
  content:string | undefined;
  summary:string | undefined;
  thumbnail:FileModel | undefined;

  init(data?: any) {
      if (data) {
          this.id = data["id"];
          this.title = data["title"];
          this.type = data["type"];
          this.content = data["content"];
          this.summary = data["v"];
          this.thumbnail = data["thumbnail"] ? FileModel.fromJS(data["thumbnail"]) : undefined;
      }
  }
  
  static fromJS(data: object): PostInputModel {
      data = typeof data === 'object' || data != null ? data : {};
      let result = new PostInputModel();
      result.init(data);
      return result;
  }
}

export interface IPostInputModel{
  id:number | undefined;
  title:string | undefined;
  type:string | undefined;
  content:string | undefined;
  summary:string | undefined;
  thumbnail:FileModel | undefined;
}

export class PostOutputModel implements IPostOutputModel {
  id!:number;
  title:string | undefined;
  type:string | undefined;
  content:string | undefined;
  summary:string | undefined;
  thumbnail:FileModel | undefined;
  permalink:string | undefined;
  metaTitle:string | undefined;
  metaDescription:string | undefined;
  createDate:string | Date | undefined;
  createUser:number | undefined;

  init(data?: any) {
      if (data) {
        this.id = data["id"];
        this.title = data["title"];
        this.type = data["type"];
        this.content = data["content"];
        this.summary = data["summary"];
        this.permalink = data["permalink"];
        this.metaTitle = data["metaTitle"];
        this.metaDescription = data["metaDescription"];
        this.createDate = data["createDate"];
        this.createUser = data["createUser"];
        this.thumbnail = data["thumbnail"] ? FileModel.fromJS(data["thumbnail"]) : undefined;
      }
  }
  
  static fromJS(data: object): PostOutputModel {
      data = typeof data === 'object' || data != null ? data : {};
      let result = new PostOutputModel();
      result.init(data);
      return result;
  }
}
export interface IPostOutputModel{
  id:number;
  title:string | undefined;
  content:string | undefined;
  summary:string | undefined;
  thumbnail:FileModel | undefined;
  permalink:string | undefined;
  metaTitle:string | undefined;
  metaDescription:string | undefined;
  createDate:string | Date | undefined;
  createUser:number | undefined;
}
