import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { Observable, Subject, of } from 'rxjs';
import { SaveResult } from '../../shared/save-result.model';
import { Order } from '../models/order.model';
@Injectable({
  providedIn: 'root'
})
export class OrderService {
  [x: string]: any;
  private URL_WORK = `${environment.apiHostUrl}/api/work`;
  filesToSave: string[] = [];

  constructor(
    private http: HttpClient
  ) { }

  AddOrder(order: Order): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORK + '/addorder';

    this.http.post(urlDoc, order).subscribe(
      res => {
        result.next(new SaveResult(false));
      },
      err => {
        console.log(err);
        result.next(new SaveResult(true));
      });
    return result.asObservable();
  }

  getMyOrders(UserId: string): Observable<Order[]> {

    const url = `${environment.apiHostUrl}/api/work/getuserorders?UserId=${UserId}`;
    return this.http
      .get<Order[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Order(item.Id, item.UserId, item.Fio, item.Phone, item.Description, item.NeedEvaluation,
            item.Status));
        })
      );
  }
  DeleteOrder(Id: string): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const url = `${environment.apiHostUrl}/api/work/delorder?Id=${Id}`;

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

  ApproveOrder(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/work/approveorder?id=${id}`;
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    this.http.get(url).subscribe(
      res => {
        result.next();
      },
      err => {
        result.next();
      }
    );
    return result.asObservable();
  }

  RejectOrder(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/work/rejectorder?id=${id}`;
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    this.http.get(url).subscribe(
      res => {
        result.next();
      },
      err => {
        result.next();
      }
    );
    return result.asObservable();
  }

}
