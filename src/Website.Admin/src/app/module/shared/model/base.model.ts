export class BasePageOutputModel<T>{
    totalItem!:number;
    items!:T[];
}

export class BasePageInputModel{
    skipCount:number = 0;
    maxCountResult:number = 50;
    search:string = '';
}
export interface IBasePageInputModel{
    skipCount:number | undefined;
    maxCountResult:number | undefined;
    search:string | undefined
}
  