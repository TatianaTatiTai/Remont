import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { WorkerService } from '../shared/worker.service';
import { Evaluation } from './models/evaluation.model';

@Component({
  selector: 'app-worker-evaluation',
  templateUrl: './worker-evaluation.component.html',
  styleUrls: ['./worker-evaluation.component.css']
})
export class WorkerEvaluationComponent implements OnInit {
  evaluation: Evaluation = new Evaluation(null, '', '', '');

  public evaluations: Evaluation;
  successMessage = 'Данные добавлены успешно.';
  errorMessage = 'Проверьте данные. Ошибка добавления.';
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
    this.getEvaluation();
  }

  OnSubmit() {
    this.spinner.show();
    this.evaluation.IdOrder = localStorage.getItem('infoId');
    this.workerService.AddEvaluation(this.evaluation).subscribe(next => {
      this.spinner.hide();
      if (next.error === false) {
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

  getEvaluation() {
    this.evaluation.IdOrder = localStorage.getItem('infoId');
    this.workerService.getEvaluation(this.evaluation.IdOrder).toPromise().then(
      data => {
        this.evaluations = data;
        console.log(data)
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
    this.evaluation = new Evaluation(null, '', '', '');
  }
}
