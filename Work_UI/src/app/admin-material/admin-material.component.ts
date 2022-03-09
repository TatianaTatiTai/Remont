import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar, PageEvent } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BehaviorSubject, Observable } from 'rxjs';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { OverviewDialogComponent } from '../overview-dialog/overview-dialog.component';
import { AdminService } from '../shared/admin.service';
import { Material } from './material/material.model';

@Component({
  selector: 'app-admin-material',
  templateUrl: './admin-material.component.html',
  styleUrls: ['./admin-material.component.css']
})
export class AdminMaterialComponent implements OnInit {
  private tempResultSubject: BehaviorSubject<Material[]> = new BehaviorSubject<Material[]>([]);
  tempResult$: Observable<Material[]> = this.tempResultSubject.asObservable();

  public material: Material[] = [];

  pageSize = 10;
  pageIndex = 0;
  length = 0;
  step = 0;

  isLoginError = false;
  newMaterial: Material = new Material(null,null, '', '', null);
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
    this.getMaterials();
  }

  AddMaterial() {
    this.spinner.show();
    this.adminService.AddMaterial(this.newMaterial).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {
        this.getMaterials();
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

  getMaterials() {
    this.adminService.getMaterials().toPromise().then(
      data => {
        this.material = data;
        this.setVariablesToDefault();
        this.step = this.material[0].Id;
        this.length = this.material.length;
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
    this.newMaterial = new Material(null, null, '', '', null);
  }


  public changePageEvent(event?: PageEvent) {
    if (event != null) {
      this.pageIndex = event.pageIndex;
      this.pageSize = event.pageSize;
    }
    this.tempResultSubject.next(this.material.slice(this.pageSize * this.pageIndex, this.pageSize * (this.pageIndex + 1)));
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
    const ind = this.material.findIndex(x => x.Id === currentStep);
    if (this.material[ind + 1] !== undefined) {
      this.step = this.material[ind + 1].Id;
    }
  }

  prevStep(currentStep: number) {
    const ind = this.material.findIndex(x => x.Id === currentStep);
    if (this.material[ind - 1] !== undefined) {
      this.step = this.material[ind - 1].Id;
    }
  }

}
