import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { User, UserReg } from './user.model';
import { Observable, Subject } from 'rxjs';
import { ProgLang } from '../user-form/models/proglang.model';
import { SaveResult } from './save-result.model';
import { Material } from '../admin-material/material/material.model';
import { WorkType } from '../admin-worktype/worktype/worktype.model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  [x: string]: any;
  private URL_REG = `${environment.apiHostUrl}/api/userregistration`;

  private URL_USER = `${environment.apiHostUrl}/api/user`;
  private URL_ADMIN = `${environment.apiHostUrl}/api/admin`;

  constructor(
    private http: HttpClient
  ) { }


  HrRegistration(newUser: UserReg): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_REG + '/addhr';

    this.http.post(urlDoc, newUser).subscribe(
      res => {
        if (res)
          result.next(new SaveResult(false));
        else
          result.next(new SaveResult(true));
      },
      error => {
        result.next(new SaveResult(true));
      });

    return result.asObservable();
  }

  DeleteUser(Id: string): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const url = `${environment.apiHostUrl}/api/user/deluser?Id=${Id}`;

    this.http.get(url).subscribe(
      res => {
        if (res)
          result.next(new SaveResult(false));
        else
          result.next(new SaveResult(true));
      },
      error => {
        result.next(new SaveResult(true));
      });

    return result.asObservable();
  }

  getUsers(): Observable<UserReg[]> {
    return this.http
      .get<UserReg[]>(this.URL_USER + '/getusers')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new UserReg(item.Id, item.Created, item.Email, item.Password, item.UserName, item.RoleId, item.Role.RoleName, item.Name, item.Surname));
        })
      );
  }

  AddMaterial(newMaterial: Material): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_ADMIN + '/addmaterial';

    this.http.post(urlDoc, newMaterial).subscribe(
      res => {
        if (res)
          result.next(new SaveResult(false));
        else
          result.next(new SaveResult(true));
      },
      error => {
        result.next(new SaveResult(true));
      });

    return result.asObservable();
  }

  getMaterials(): Observable<Material[]> {
    return this.http
      .get<Material[]>(this.URL_ADMIN + '/getmaterials')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Material(item.Id, item.Material, item.Manufacturer, item.Description, item.OneCost));
        })
      );
  }

  getWorkTypes(): Observable<WorkType[]> {
    return this.http
      .get<WorkType[]>(this.URL_ADMIN + '/getworktypes')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new WorkType(item.Id, item.WorkType, item.OneCost));
        })
      );
  }

  AddWorkType(newWorkType: WorkType): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_ADMIN + '/addworktype';

    this.http.post(urlDoc, newWorkType).subscribe(
      res => {
        if (res)
          result.next(new SaveResult(false));
        else
          result.next(new SaveResult(true));
      },
      error => {
        result.next(new SaveResult(true));
      });

    return result.asObservable();
  }
  private getOptionsCustom(Id: string) {
    return {
      params: new HttpParams()
        .set('Id', Id)
    };
  }
}
