import { Component, OnInit } from '@angular/core';
import { UploadEvent, UploadFile, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { MatSnackBar, MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { WorkerService } from '../shared/worker.service';
import { OrderMaterial } from '../worker-ordermaterial/ordermaterial/ordermaterial.model';
import { WorkerCost } from '../worker-orderworkercost/models/workercost.model';
import { OrderWorkType } from '../worker-orderworktype/models/orderworktype.model';
import { TextInfo } from '../order/models/text.model';
import { HttpResponse } from '@angular/common/http';
import * as fileSaver from 'file-saver';

@Component({
  selector: 'app-worker-orderfull',
  templateUrl: './worker-orderfull.component.html',
  styleUrls: ['./worker-orderfull.component.css']
})
export class WorkerOrderFullComponent implements OnInit {

  public files: UploadFile[] = [];
  public materialOrder: OrderMaterial[] = [];
  public workerCost: WorkerCost[] = [];
  public worktypeOrder: OrderWorkType[] = [];

  textInfo: TextInfo[] = [];
  public sumMat: number;
  public sumWorkT: number;
  public sumCost: number;
  public finalCost: number;

  public id = localStorage.getItem('infoId');
  public status = localStorage.getItem('statusForm');


  successMessage = 'Документ сохранен успешно.';
  errorMessage = 'Документ не сохранен! Произошла ошибка!';
  notSupportedMessage = 'Данный тип файлов не поддерживается.';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private workerService: WorkerService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService,
    private previewDialog: FilePreviewOverlayService
  ) { }

  ngOnInit() {
    this.getOrderMaterials();
    this.getOrderWorkTypes();
    this.getWorkerCosts();
    this.getNamesOfTexts();
  }

  getNamesOfTexts() {
    const IdOrder = localStorage.getItem('infoId');
    this.workerService.getNamesOfTexts(IdOrder).subscribe(textsInfo => {
      this.textInfo = textsInfo;
    });

  }
  getOrderMaterials() {
    const IdOrder = localStorage.getItem('infoId');
    this.workerService.getOrderMaterials(IdOrder).toPromise().then(
      data => {
        this.materialOrder = data;
        this.workerService.getOrderMaterialsSum(IdOrder).toPromise().then(
          data => {
            this.sumMat = data;
          });
      });
  }
  getWorkerCosts() {
    const IdOrder = localStorage.getItem('infoId');
    this.workerService.getWorkerCosts(IdOrder).toPromise().then(
      data => {
        this.workerCost = data;
        this.workerService.getWorkerCostsSum(IdOrder).toPromise().then(
          data => {
            this.sumCost = data;
          });
      });
  }
  getOrderWorkTypes() {
    const IdOrder = localStorage.getItem('infoId');
    this.workerService.getOrderWorkTypes(IdOrder).toPromise().then(
      data => {
        this.worktypeOrder = data;
        this.workerService.getOrderWorkTypesSum(IdOrder).toPromise().then(
          data => {
            this.sumWorkT = data;
          });
      });
  }
  showSnackBar(message: string, typeClass: string) {
    this.snackBar.open(message, null, {
      duration: 3000,
      verticalPosition: 'top',
      horizontalPosition: 'center',
      panelClass: [typeClass]
    });
  }


  public dropped(event: UploadEvent) {
    this.files = [...this.files, ...event.files];
    for (const droppedFile of event.files) {
      if (droppedFile.fileEntry.isFile) {
        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
        fileEntry.file((file: File) => {
          console.log(file.name);
        });
      } else {
        const fileEntry = droppedFile.fileEntry as FileSystemDirectoryEntry;
      }
    }
  }

  public deleteFileItem(file: UploadFile) {
    const index = this.files.indexOf(file, 0);
    if (index > -1) {
      this.files.splice(index, 1);
    }
  }
  SaveDocument() {
    this.spinner.show();

    const id = localStorage.getItem('infoId');
    this.workerService.saveTexts(id, this.files).subscribe(next => {
      this.spinner.hide();
      if (next.error === false) {
        this.showSnackBar(this.successMessage, this.successStyle);
        this.files = [];
        this.getNamesOfTexts();
      } else {
        if (next.errorFiles === null || next.errorFiles === undefined) {
          this.showSnackBar(this.successMessage, this.successStyle);
          this.files = [];
          this.getNamesOfTexts();
        } else {
          this.showSnackBar(this.errorMessage, this.errorStyle);
        }
      }
    }, error => {
      console.log(error);
      this.spinner.hide();
    });
  }

  downloadTextById(textArchiveID: number) {
    this.workerService.downloadTextById(textArchiveID)
      .subscribe(response => {
        const filename = decodeURI(this.getFileNameFromHttpResponse(response).replace(/\+/g, '%20'));
        const fileType = this.getFileTypeFromFileName(filename);
        this.saveFile(response.body, filename, fileType);
      }, error => {
      });
  }

  private saveFile(data: any, filename?: string, fileType?: string) {
    const blob = new Blob([data], { type: fileType });
    fileSaver.saveAs(blob, filename);
  }

  private getFileNameFromHttpResponse(response: HttpResponse<Blob>): string {
    const contentDispositionHeader = response.headers.get('Content-Disposition');
    const result = contentDispositionHeader.split(';')[1].trim().split('=')[1].trim();
    return result;
  }

  private getFileTypeFromFileName(fileName: string): string {
    const checkFileType = fileName.split('.').pop();
    let fileType: string;
    switch (checkFileType) {
      case 'txt': {
        fileType = 'text/plain';
        break;
      }
      case 'pdf': {
        fileType = 'application/pdf';
        break;
      }
      case 'doc':
      case 'docx': {
        fileType = 'application/vnd.ms-word';
        break;
      }
      case 'xls': {
        fileType = 'application/vnd.ms-excel';
        break;
      }
      case 'png': {
        fileType = 'image/png';
        break;
      }
      case 'jpeg':
      case 'jpg': {
        fileType = 'image/jpeg';
        break;
      }
      case 'gif': {
        fileType = 'image/gif';
        break;
      }
      case 'csv': {
        fileType = 'text/csv';
        break;
      }
      default: {
        break;
      }
    }

    return fileType;
  }
}
