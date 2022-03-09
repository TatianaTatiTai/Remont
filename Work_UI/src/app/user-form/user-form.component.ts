import { Component, OnInit } from '@angular/core';
import { UploadEvent, UploadFile, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { MatSnackBar, MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { OverviewDialogComponent } from '../overview-dialog/overview-dialog.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { PersonalInfo } from './models/personalInfo.model';
import { UserFormService } from './service/user-form.service';
import { Language } from './models/language.model';
import { EducationInfo } from './models/educationInfo.model';
import { Experience } from './models/experience.model';
import { ProgLang } from './models/proglang.model';
import { AdminService } from '../shared/admin.service';
import { UserProgLang } from './models/userProgLang.model';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {
  public files: UploadFile[] = [];

  public progLang: ProgLang[] = [];

  isLoginError = false;
  info: PersonalInfo = new PersonalInfo(null, '', '', '', '', '', '', '', '', '', null, null, '', '');
  educationInfo: EducationInfo = new EducationInfo(null, '', '', '', '', '', '', '', '', '', null);
  language: Language = new Language(null, '', '', '', '', '', '', '', '');
  userProgLang: UserProgLang = new UserProgLang(null, '', null, '', '', '', '');
  experience: Experience = new Experience(null, '', '', '', '');
  successMessage = 'Данные добавлены успешно.';
  errorMessage = 'Проверьте данные. Ошибка добавления.';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private userFormService: UserFormService,
    private adminService: AdminService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService,
    private previewDialog: FilePreviewOverlayService
  ) { }

  ngOnInit() {

    this.getProgLangs();

  }
  OnSubmit() {
    this.spinner.show();
    this.info.UserId = localStorage.getItem('userId');
    this.educationInfo.UserId = localStorage.getItem('userId');
    this.language.UserId = localStorage.getItem('userId');
    this.experience.UserId = localStorage.getItem('userId');
    console.log(this.experience)
    this.userFormService.AddPersonalInfo(this.info).subscribe(next => {

      if (next.error === false) {
        this.userFormService.AddEducation(this.educationInfo).subscribe(next => {
          if (next.error === false) {
            this.userFormService.AddLanguage(this.language).subscribe(next => {
              if (next.error === false) {
                this.spinner.hide();
                this.userFormService.AddExperience(this.experience);
                this.showSnackBar(this.successMessage, this.successStyle);
                this.setObjectsToDefault();
              } else {
                this.dialog.open(OverviewDialogComponent, { data: { type: 'error' } });
              }
            });
          }
        });
      } else {
        this.dialog.open(OverviewDialogComponent, { data: { type: 'error' } });
      }

    }, error => {
      console.log(error);
      this.spinner.hide();
    });
  }

  AddProg() {
    this.spinner.show();
    this.userProgLang.UserId = localStorage.getItem('userId');
    this.userFormService.AddProgLang(this.userProgLang).subscribe(next => {
      this.spinner.hide();
      if (next.error === false) {
        this.showSnackBar(this.successMessage, this.successStyle);
      } else {        
          this.showSnackBar(this.errorMessage, this.errorStyle);       
      }
    }, error => {
      console.log(error);
      this.spinner.hide();
    });
  }

  getProgLangs() {
    this.adminService.getProgLangs().toPromise().then(
      data => {
        this.progLang = data;
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
    this.info = new PersonalInfo('', '', '', '', '', '', '', '', '', '', null, null, '', '');
    this.educationInfo = new EducationInfo('', '', '', '', '', '', '', '', '', '', null);

    this.language = new Language(null, '', '', '', '', '', '', '', '');
    this.experience = new Experience(null, '', '', '', '');
  }

}
