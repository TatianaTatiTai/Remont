import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar, PageEvent } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BehaviorSubject, Observable } from 'rxjs';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { OverviewDialogComponent } from '../overview-dialog/overview-dialog.component';
import { AdminService } from '../shared/admin.service';
import { WorkType } from './worktype/worktype.model';

@Component({
  selector: 'app-admin-worktype',
  templateUrl: './admin-worktype.component.html',
  styleUrls: ['./admin-worktype.component.css']
})
export class AdminWorktypeComponent implements OnInit {

  private tempResultSubject: BehaviorSubject<WorkType[]> = new BehaviorSubject<WorkType[]>([]);
  tempResult$: Observable<WorkType[]> = this.tempResultSubject.asObservable();

  public workType: WorkType[] = [];

  pageSize = 10;
  pageIndex = 0;
  length = 0;
  step = 0;

  isLoginError = false;
  newWorkType: WorkType = new WorkType(null, '',null);
  successMessage = 'Материал добавлен успешно.';
  errorMessage = 'Проверьте данные. Ошибка добавления.';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private adminService: AdminService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService,
    private previewDialog: FilePreviewOverlayService
  ) { }

  ngOnInit() {
    this.getWorkTypes();
  }

  AddWorkType() {
    this.spinner.show();
    this.adminService.AddWorkType(this.newWorkType).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {
        this.getWorkTypes();
        this.showSnackBar(this.successMessage, this.successStyle);
        this.setObjectsToDefault();
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

  getWorkTypes() {
    this.adminService.getWorkTypes().toPromise().then(
      data => {
        this.workType = data;
        this.setVariablesToDefault();
        this.step = this.workType[0].Id;
        this.length = this.workType.length;
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
    this.newWorkType = new WorkType(null, '', null);
  }


  public changePageEvent(event?: PageEvent) {
    if (event != null) {
      this.pageIndex = event.pageIndex;
      this.pageSize = event.pageSize;
    }
    this.tempResultSubject.next(this.workType.slice(this.pageSize * this.pageIndex, this.pageSize * (this.pageIndex + 1)));
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
    const ind = this.workType.findIndex(x => x.Id === currentStep);
    if (this.workType[ind + 1] !== undefined) {
      this.step = this.workType[ind + 1].Id;
    }
  }

  prevStep(currentStep: number) {
    const ind = this.workType.findIndex(x => x.Id === currentStep);
    if (this.workType[ind - 1] !== undefined) {
      this.step = this.workType[ind - 1].Id;
    }
  }

}
