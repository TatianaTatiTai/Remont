import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar, PageEvent } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BehaviorSubject, Observable } from 'rxjs';
import { Material } from '../admin-material/material/material.model';
import { WorkType } from '../admin-worktype/worktype/worktype.model';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { OverviewDialogComponent } from '../overview-dialog/overview-dialog.component';
import { AdminService } from '../shared/admin.service';
import { WorkerService } from '../shared/worker.service';
import { Evaluation } from '../worker-evaluation/models/evaluation.model';
import { OrderWorkType } from '../worker-orderworktype/models/orderworktype.model';

@Component({
  selector: 'app-worker-orderworktype',
  templateUrl: './worker-orderworktype.component.html',
  styleUrls: ['./worker-orderworktype.component.css']
})
export class WorkerOrderworktypeComponent implements OnInit {
  private tempResultSubject: BehaviorSubject<OrderWorkType[]> = new BehaviorSubject<OrderWorkType[]>([]);
  tempResult$: Observable<OrderWorkType[]> = this.tempResultSubject.asObservable();

  public worktypeOrder: OrderWorkType[] = [];
  public worktype: WorkType[] = [];


  public evaluations: Evaluation;
  evaluation: Evaluation = new Evaluation(null, '', '', '');

  pageSize = 10;
  pageIndex = 0;
  length = 0;
  step = 0;

  public oneCost: number;
  public cost: number;

  isLoginError = false;
  newWorkType: OrderWorkType = new OrderWorkType(null, null,null, '', null, null);
  successMessage = 'Работы добавлен успешно.';
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
    this.getEvaluation();
    this.getWorkTypes();
    this.getOrderWorkTypes();
  }

  getEvaluation() {
    this.evaluation.IdOrder = localStorage.getItem('infoId');
    this.workerService.getEvaluation(this.evaluation.IdOrder).toPromise().then(
      data => {
        this.evaluations = data;
        console.log(data)
      });
  }

  AddWorkType(IdWorkType, Amount) {
    this.newWorkType.IdOrder = localStorage.getItem('infoId');
    this.newWorkType.IdWorkType = IdWorkType;
    this.newWorkType.Amount = Amount;
    console.log(this.newWorkType.Amount)
    this.spinner.show();

    this.workerService.getOneCostWorkType(this.newWorkType.IdWorkType).toPromise().then(
      data => {
        this.oneCost = data;
        this.newWorkType.Cost = this.newWorkType.Amount * this.oneCost;

        console.log(this.newWorkType.Amount)
    this.workerService.AddWorkTypeOrder(this.newWorkType).subscribe(next => {
      this.spinner.hide();
      if (next.error === false) {
        this.getOrderWorkTypes();
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

  getOrderWorkTypes() {
    this.newWorkType.IdOrder = localStorage.getItem('infoId');
    this.workerService.getOrderWorkTypes(this.newWorkType.IdOrder).toPromise().then(
      data => {
        this.worktypeOrder = data;
        console.log(data)
        this.setVariablesToDefault();
        this.step = this.worktype[0].Id;
        this.length = this.worktype.length;
        this.changePageEvent();
      });
  }

  getWorkTypes() {
    this.adminService.getWorkTypes().toPromise().then(
      data => {
        this.worktype = data;
        this.setVariablesToDefault();
        this.step = this.worktype[0].Id;
        this.length = this.worktype.length;
        this.changePageEvent();
      });
  }

  deleteOrderWorkType(Id) {
    this.workerService.DeleteOrderWorkType(Id).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {

        this.getOrderWorkTypes();
      } else {
        if (next.errorFiles === null || next.errorFiles === undefined) {
          this.showSnackBar(this.errorMessage, this.errorStyle);
        } else {
          this.dialog.open(OverviewDialogComponent, { data: { type: 'error' } });
        }
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
    this.newWorkType = new OrderWorkType(null, null, null, '', null, null);;
  }


  public changePageEvent(event?: PageEvent) {
    if (event != null) {
      this.pageIndex = event.pageIndex;
      this.pageSize = event.pageSize;
    }
    this.tempResultSubject.next(this.worktypeOrder.slice(this.pageSize * this.pageIndex, this.pageSize * (this.pageIndex + 1)));
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
    const ind = this.worktype.findIndex(x => x.Id === currentStep);
    if (this.worktype[ind + 1] !== undefined) {
      this.step = this.worktype[ind + 1].Id;
    }
  }

  prevStep(currentStep: number) {
    const ind = this.worktype.findIndex(x => x.Id === currentStep);
    if (this.worktype[ind - 1] !== undefined) {
      this.step = this.worktype[ind - 1].Id;
    }
  }

}
