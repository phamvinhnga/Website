export class FileModel implements IFileModel {
    id:string | undefined;
    name:string | undefined;
    url:string | undefined | ArrayBuffer;
    type:string | undefined;

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.name = data["name"];
            this.url = data["url"];
            this.type = data["type"];
        }
    }
    
    static fromJS(data: object): FileModel {
        data = typeof data === 'object' || data ? data : {};
        let result = new FileModel();
        result.init(data);
        return result;
    }
}

export interface IFileModel{
    id:string | undefined;
    name:string | undefined;
    url:string | undefined | ArrayBuffer;
    type:string | undefined;
}