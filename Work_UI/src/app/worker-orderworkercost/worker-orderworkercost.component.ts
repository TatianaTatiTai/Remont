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
import { WorkerCost } from './models/workercost.model';

@Component({
  selector: 'app-worker-orderworkercost',
  templateUrl: './worker-orderworkercost.component.html',
  styleUrls: ['./worker-orderworkercost.component.css']
})
export class WorkerOrderworkercostComponent implements OnInit {
  private tempResultSubject: BehaviorSubject<WorkerCost[]> = new BehaviorSubject<WorkerCost[]>([]);
  tempResult$: Observable<WorkerCost[]> = this.tempResultSubject.asObservable();

  public workerCost: WorkerCost[] = [];

  pageSize = 10;
  pageIndex = 0;
  length = 0;
  step = 0;

  public evaluations: Evaluation;
  evaluation: Evaluation = new Evaluation(null, '', '', '');

  newWorkerCost: WorkerCost = new WorkerCost(null, null, '', '');
  successMessage = 'Стоимость бригады добавлена успешно.';
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
    this.getWorkerCosts();

    this.getEvaluation();
  }
  getEvaluation() {
    this.evaluation.IdOrder = localStorage.getItem('infoId');
    this.workerService.getEvaluation(this.evaluation.IdOrder).toPromise().then(
      data => {
        this.evaluations = data;
        console.log(data)
      });
  }
  AddWorkerCost() {
    this.newWorkerCost.IdOrder = localStorage.getItem('infoId');
    this.spinner.show();
    this.workerService.AddWorkerCost(this.newWorkerCost).subscribe(next => {
      this.spinner.hide();
      if (next.error === false) {
        this.getWorkerCosts();
        this.showSnackBar(this.successMessage, this.successStyle);
        this.setObjectsToDefault();
      } else {    
          this.showSnackBar(this.errorMessage, this.errorStyle);       
      }
    }, error => {
      console.log(error);
      this.spinner.hide();
    });
  }

 
  getWorkerCosts() {
    this.newWorkerCost.IdOrder = localStorage.getItem('infoId');
    this.workerService.getWorkerCosts(this.newWorkerCost.IdOrder).toPromise().then(
      data => {
        this.workerCost = data;
        this.setVariablesToDefault();
        this.step = this.workerCost[0].Id;
        this.length = this.workerCost.length;
        this.changePageEvent();
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
    this.newWorkerCost = new WorkerCost(null, null, '', '');
  }


  public changePageEvent(event?: PageEvent) {
    if (event != null) {
      this.pageIndex = event.pageIndex;
      this.pageSize = event.pageSize;
    }
    this.tempResultSubject.next(this.workerCost.slice(this.pageSize * this.pageIndex, this.pageSize * (this.pageIndex + 1)));
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
    const ind = this.workerCost.findIndex(x => x.Id === currentStep);
    if (this.workerCost[ind + 1] !== undefined) {
      this.step = this.workerCost[ind + 1].Id;
    }
  }

  prevStep(currentStep: number) {
    const ind = this.workerCost.findIndex(x => x.Id === currentStep);
    if (this.workerCost[ind - 1] !== undefined) {
      this.step = this.workerCost[ind - 1].Id;
    }
  }

}
