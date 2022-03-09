import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, Subject, of } from 'rxjs';
import { UploadFile, FileSystemFileEntry } from 'ngx-file-drop';
import { PersonalInfo } from '../models/personalInfo.model';
import { Language } from '../models/language.model';
import { map } from 'rxjs/operators';
import { EducationInfo } from '../models/educationInfo.model';
import { Experience } from '../models/experience.model';
import { UserProgLang } from '../models/userProgLang.model';
import { SaveResult } from '../../shared/save-result.model';
@Injectable({
  providedIn: 'root'
})
export class UserFormService {
  [x: string]: any;
  private URL_WORK = `${environment.apiHostUrl}/api/userform`;
  filesToSave: string[] = [];

  constructor(
    private http: HttpClient
  ) { }


  AddPersonalInfo(info: PersonalInfo): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORK + '/addinfo';

    this.http.post(urlDoc, info).subscribe(
      res => {
        result.next(new SaveResult(false));
      },
      err => {
        console.log(err);
        result.next(new SaveResult(true));
      });
    return result.asObservable();
  }

  AddEducation(education: EducationInfo): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORK + '/addeducation';

    this.http.post(urlDoc, education).subscribe(
      res => {
        result.next(new SaveResult(false));
      },
      err => {
        console.log(err);
        result.next(new SaveResult(true));
      });
    return result.asObservable();
  }

  AddLanguage(language: Language): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORK + '/addlanguage';

    this.http.post(urlDoc, language).subscribe(
      res => {
        result.next(new SaveResult(false));
      },
      err => {
        console.log(err);
        result.next(new SaveResult(true));
      });
    return result.asObservable();
  }

  AddExperience(experience: Experience): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORK + '/addexperience';

    this.http.post(urlDoc, experience).subscribe(
      res => {
        result.next(new SaveResult(false));
      },
      err => {
        console.log(err);
        result.next(new SaveResult(true));
      });
    return result.asObservable();
  }


  AddProgLang(proglang: UserProgLang): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORK + '/adduserproglang';

    this.http.post(urlDoc, proglang).subscribe(
      res => {
        result.next(new SaveResult(false));
      },
      err => {
        console.log(err);
        result.next(new SaveResult(true));
      });
    return result.asObservable();
  }

  getUserStatus(id: string): Observable<PersonalInfo[]> {

    const url = `${environment.apiHostUrl}/api/userform/getuserstatus?id=${id}`;
    return this.http
      .get<PersonalInfo[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new PersonalInfo(item.Id, item.UserId, item.Name, item.Surname, item.Patronymic,
            item.Date, item.Adress, item.Phone, item.Email,
            item.Position, item.MinSalary, item.MaxSalary, item.CreateDate, item.Status));
        })
      );
  }
}
