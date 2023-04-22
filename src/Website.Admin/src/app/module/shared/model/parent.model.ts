import { FileModel } from "./file.model";

export class ParentOutputModel implements IParentOutputModel {
    id!: number;
    surname: string | undefined;
    name: string | undefined;
    fullName: string | undefined;
    profession: string | undefined;
    feedback: string | undefined;
    index: number | undefined
    isDisplayIndexPage!: boolean;
    thumbnail: FileModel | undefined;
    createDate:string | Date | undefined;
    createUser:number | undefined;

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.surname = data["surname"];
            this.name = data["name"];
            this.fullName = data["fullName"];
            this.profession = data["profession"];
            this.feedback = data["feedback"];
            this.index = data["index"];
            this.isDisplayIndexPage = data["isDisplayIndexPage"];
            this.createDate = data["createDate"];
            this.createUser = data["createUser"];
            this.thumbnail = data["thumbnail"] ? FileModel.fromJS(data["thumbnail"]) : undefined;
        }
    }

    static fromJS(data: object): ParentOutputModel {
        data = typeof data === 'object' || data != null ? data : {};
        let result = new ParentOutputModel();
        result.init(data);
        return result;
    }
}

export class ParentInputModel implements IParentInputModel {
    id: number | undefined;
    surname: string | undefined;
    name: string | undefined;
    profession: string | undefined;
    feedback: string | undefined;
    index: number | undefined;
    isDisplayIndexPage: boolean | undefined;
    thumbnail: FileModel | undefined;

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.surname = data["surname"];
            this.name = data["name"];
            this.profession = data["profession"];
            this.feedback = data["feedback"];
            this.index = data["index"];
            this.isDisplayIndexPage = data["isDisplayIndexPage"];
            this.thumbnail = data["thumbnail"] ? FileModel.fromJS(data["thumbnail"]) : undefined;
        }
    }

    static fromJS(data: object): ParentInputModel {
        data = typeof data === 'object' || data != null ? data : {};
        let result = new ParentInputModel();
        result.init(data);
        return result;
    }
}

export interface IParentInputModel {
    id: number | undefined;
    surname: string | undefined;
    name: string | undefined;
    profession: string | undefined;
    feedback: string | undefined;
    index: number | undefined
    isDisplayIndexPage: boolean | undefined;
    thumbnail: FileModel | undefined;
}

export interface IParentOutputModel {
    id: number;
    surname: string | undefined;
    name: string | undefined;
    fullName: string | undefined;
    profession: string | undefined;
    feedback: string | undefined;
    index: number | undefined
    isDisplayIndexPage: boolean | undefined;
    thumbnail: FileModel | undefined;
    createDate:string | Date | undefined;
    createUser:number | undefined;
}