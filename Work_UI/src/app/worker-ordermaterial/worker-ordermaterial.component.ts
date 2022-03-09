import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar, PageEvent } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BehaviorSubject, Observable } from 'rxjs';
import { Material } from '../admin-material/material/material.model';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { OverviewDialogComponent } from '../overview-dialog/overview-dialog.component';
import { AdminService } from '../shared/admin.service';
import { WorkerService } from '../shared/worker.service';
import { Evaluation } from '../worker-evaluation/models/evaluation.model';
import { OrderMaterial } from './ordermaterial/ordermaterial.model';

@Component({
  selector: 'app-worker-ordermaterial',
  templateUrl: './worker-ordermaterial.component.html',
  styleUrls: ['./worker-ordermaterial.component.css']
})
export class WorkerOrdermaterialComponent implements OnInit {
  private tempResultSubject: BehaviorSubject<OrderMaterial[]> = new BehaviorSubject<OrderMaterial[]>([]);
  tempResult$: Observable<OrderMaterial[]> = this.tempResultSubject.asObservable();

  public material: Material[] = [];
  public oneCost: number;
  public cost: number;
  public IdOrder: string;
  public materialOrder: OrderMaterial[] = [];

  pageSize = 10;
  pageIndex = 0;
  length = 0;
  step = 0;

  public evaluations: Evaluation;
  evaluation: Evaluation = new Evaluation(null, '', '', '');

  isLoginError = false;
  newMaterial: OrderMaterial = new OrderMaterial(null, null, '', '', null, null);
  successMessage = 'Материал добавлен успешно.';
  errorMessage = 'Проверьте данные. Ошибка добавления.';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private workerService: WorkerService,
    private adminService: AdminService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService,
    private previewDialog: FilePreviewOverlayService
  ) { }

  ngOnInit() {
    this.getMaterials();
    this.getOrderMaterials();
    this.getEvaluation();
  }

  AddMaterial(IdMaterial, Amount) {
    this.newMaterial.IdOrder = localStorage.getItem('infoId');
    this.newMaterial.IdMaterial = IdMaterial;
    this.newMaterial.Amount = Amount;

    this.workerService.getOneCost(this.newMaterial.IdMaterial).toPromise().then(
      data => {
        this.oneCost = data;
        this.newMaterial.Cost = this.newMaterial.Amount * this.oneCost;
        this.workerService.AddMaterialOrder(this.newMaterial).subscribe(next => {
          console.log(next)
          this.spinner.hide();
          if (next.error === false) {
            this.getOrderMaterials();
            this.showSnackBar(this.successMessage, this.successStyle);
            this.setObjectsToDefault();
          } else {

            this.showSnackBar(this.errorMessage, this.errorStyle);
          }
        }, error => {
          console.log(error);
          this.spinner.hide();
        });
      });
  }

  getMaterials() {
    this.adminService.getMaterials().toPromise().then(
      data => {
        this.material = data;
        console.log(data)

      });

  }
  getOrderMaterials() {
    this.newMaterial.IdOrder = localStorage.getItem('infoId');
    this.workerService.getOrderMaterials(this.newMaterial.IdOrder).toPromise().then(
      data => {
        this.materialOrder = data;
        this.setVariablesToDefault();
        this.step = this.material[0].Id;
        this.length = this.material.length;
        this.changePageEvent();
      });
  }
  deleteOrderMaterial(Id) {
    this.workerService.DeleteOrderMaterial(Id).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {

        this.getOrderMaterials();
      } else {
        this.showSnackBar(this.errorMessage, this.errorStyle);
      }
    }, error => {
      console.log(error);
      this.spinner.hide();
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

  setObjectsToDefault() {
    this.newMaterial = new OrderMaterial(null, null, '', '', null, null);
  }


  getEvaluation() {
    this.evaluation.IdOrder = localStorage.getItem('infoId');
    this.workerService.getEvaluation(this.evaluation.IdOrder).toPromise().then(
      data => {
        this.evaluations = data;
        console.log(data)
      });
  }
  public changePageEvent(event?: PageEvent) {
    if (event != null) {
      this.pageIndex = event.pageIndex;
      this.pageSize = event.pageSize;
    }
    this.tempResultSubject.next(this.materialOrder.slice(this.pageSize * this.pageIndex, this.pageSize * (this.pageIndex + 1)));
    return event;
  }

  private setVariablesToDefault() {
    this.pageSize = 10;
    this.pageIndex = 0;
    this.length = 0;
  }

  setStep(index: number) {
    this.step = index;
  }

  nextStep(currentStep: number) {
    const ind = this.materialOrder.findIndex(x => x.Id === currentStep);
    if (this.materialOrder[ind + 1] !== undefined) {
      this.step = this.materialOrder[ind + 1].Id;
    }
  }

  prevStep(currentStep: number) {
    const ind = this.materialOrder.findIndex(x => x.Id === currentStep);
    if (this.materialOrder[ind - 1] !== undefined) {
      this.step = this.materialOrder[ind - 1].Id;
    }
  }

}
