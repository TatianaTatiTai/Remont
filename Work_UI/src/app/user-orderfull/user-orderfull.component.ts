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
  selector: 'app-user-orderfull',
  templateUrl: './user-orderfull.component.html',
  styleUrls: ['./user-orderfull.component.css']
})
export class UserOrderFullComponent implements OnInit {

  public materialOrder: OrderMaterial[] = [];
  public workerCost: WorkerCost[] = [];
  public worktypeOrder: OrderWorkType[] = [];
  public sumMat: number = 0;
  public sumWorkT: number = 0;
  public sumCost: number = 0;
  public finalCost: number = 0;

  public id = localStorage.getItem('infoId');
  public status = localStorage.getItem('statusForm');

  textInfo: TextInfo[] = [];
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
