import { SummernoteOptions } from "ngx-summernote/lib/summernote-options";
import * as _ from 'lodash';
import { FileModel, IFileModel } from "./file.model";
import { FormGroup } from "@angular/forms";

export class BaseComponent {

  title:string | undefined;
  form: FormGroup | undefined;
  summernoteOptions: SummernoteOptions = {
    placeholder: '',
    tabsize: 2,
    toolbar: [
      ['misc', ['codeview', 'undo', 'redo']],
      ['style', ['bold', 'italic', 'underline', 'clear']],
      ['font', ['bold', 'italic', 'underline', 'strikethrough', 'superscript', 'subscript', 'clear']],
      ['fontsize', ['fontname', 'fontsize', 'color']],
      ['para', ['style', 'ul', 'ol', 'paragraph', 'height']],
      ['insert', ['table', 'picture', 'link', 'video', 'hr']]
    ],
    popover: {
      image: [
        ['image', ['resizeFull', 'resizeHalf', 'resizeQuarter', 'resizeNone']],
        ['float', ['floatLeft', 'floatRight', 'floatNone']],
        ['remove', ['removeMedia']]
      ],
      link: [
        ['link', ['linkDialogShow', 'unlink']]
      ],
      table: [
        ['add', ['addRowDown', 'addRowUp', 'addColLeft', 'addColRight']],
        ['delete', ['deleteRow', 'deleteCol', 'deleteTable']],
      ],
      air: [
        ['color', ['color']],
        ['font', ['bold', 'underline', 'clear']],
        ['para', ['ul', 'paragraph']],
        ['table', ['table']],
        ['insert', ['link', 'picture']]
      ]
    }
  };

  listFileImage:FileModel[] = [];

  async onHandleUploadImage(event: any): Promise<FileModel[]> {
    if(!this.listFileImage){
      this.listFileImage = [];
    }
    _.each(event?.target?.files, async (file: File) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      await new Promise((resolve, reject) => {
        reader.onload = () => {
          this.listFileImage.push({
            name: file.name,
            type: file.type,
            url: reader.result
          } as FileModel)
        };
      });

    });
    return this.listFileImage;
  }

  onRemoveFileImage(){
    this.listFileImage = [];
  }
}
