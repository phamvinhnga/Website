import { FileModel } from "./file.model";

export class SpecializedOutputModel implements ISpecializedOutputModel {
    id!: number;
    name: string | undefined;
    createDate:string | Date | undefined;
    createUser:number | undefined;

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.name = data["name"];
            this.createDate = data["createDate"];
            this.createUser = data["createUser"];
        }
    }

    static fromJS(data: object): SpecializedOutputModel {
        data = typeof data === 'object' || data != null ? data : {};
        let result = new SpecializedOutputModel();
        result.init(data);
        return result;
    }
}

export class SpecializedInputModel implements ISpecializedInputModel {
    id: number | undefined;
    name: string | undefined;

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.name = data["name"];
        }
    }

    static fromJS(data: object): SpecializedInputModel {
        data = typeof data === 'object' || data != null ? data : {};
        let result = new SpecializedInputModel();
        result.init(data);
        return result;
    }
}

export interface ISpecializedInputModel {
    id: number | undefined;
    name: string | undefined;
}

export interface ISpecializedOutputModel {
    id: number;
    name: string | undefined;
    createDate:string | Date | undefined;
    createUser:number | undefined;
}