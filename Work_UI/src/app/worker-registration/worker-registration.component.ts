import { Component, OnInit } from '@angular/core';
import { UploadEvent, UploadFile, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { MatSnackBar, MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { OverviewDialogComponent } from '../overview-dialog/overview-dialog.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { FilePreviewOverlayRef } from '../file-preview/file-preview-overlay/file-preview-overlay-ref';
import { DatePipe } from '@angular/common';
import { AdminService } from '../shared/admin.service';
import { UserReg } from '../shared/user.model';

@Component({
  selector: 'app-worker-registration',
  templateUrl: './worker-registration.component.html',
  styleUrls: ['./worker-registration.component.css']
})
export class WorkerRegistrationComponent implements OnInit {
  public files: UploadFile[] = [];

  isLoginError = false;
  newUser: UserReg = new UserReg('', '', '', '', '', '', '', '','');
  successMessage = 'Новый сотрудник добавлен успешно.';
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

  }
  OnSubmit() {
    this.spinner.show();
    this.adminService.HrRegistration(this.newUser).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {
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
  showSnackBar(message: string, typeClass: string) {
    this.snackBar.open(message, null, {
      duration: 3000,
      verticalPosition: 'top',
      horizontalPosition: 'center',
      panelClass: [typeClass]
    });
  }

  setObjectsToDefault() {
    this.newUser = new UserReg('', '', '', '', '', '', '', '','');
  }
}
