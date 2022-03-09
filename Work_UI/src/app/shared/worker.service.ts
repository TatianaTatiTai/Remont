import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { User, UserReg } from './user.model';
import { Observable, Subject } from 'rxjs';
import { SaveResult } from './save-result.model';
import { Order } from '../order/models/order.model';
import { OrderMaterial } from '../worker-ordermaterial/ordermaterial/ordermaterial.model';
import { OrderWorkType } from '../worker-orderworktype/models/orderworktype.model';
import { WorkerCost } from '../worker-orderworkercost/models/workercost.model';
import { Evaluation } from '../worker-evaluation/models/evaluation.model';
import { FileSystemFileEntry, UploadFile } from 'ngx-file-drop';
import { TextInfo } from '../order/models/text.model';

@Injectable({
  providedIn: 'root'
})
export class WorkerService {
  [x: string]: any;

  filesToSave: string[] = [];
  private URL_WORKER = `${environment.apiHostUrl}/api/worker`;

  constructor(
    private http: HttpClient
  ) { }

  saveTexts(id: string, files: UploadFile[]): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    let countRequetsts = 0;
    let countResponses = 0;
    const urlFile = this.URL_WORKER + '/uploadFiles';

    for (const entryFile of files) {
      const file = entryFile.fileEntry as FileSystemFileEntry;
      this.filesToSave.push(file.name);

      file.file((_file: File) => {
        const formData = new FormData();
        formData.append('IdOrder', id);
        formData.append('textsCount', files.length.toString());
        formData.append('textIndex', countRequetsts.toString());
        formData.append(_file.name, _file, _file.name);
        countRequetsts++;

        this.http.post(urlFile, formData).subscribe(
          res => {
            const index = this.filesToSave.indexOf(_file.name, 0);
            if (index > -1) {
              this.filesToSave.splice(index, 1);
            }
            countResponses++;
            if (countRequetsts === countResponses) {
              result.next(new SaveResult(true));
            }
          },
          err => {
            countResponses++;
            if (countRequetsts === countResponses) {
              result.next(new SaveResult(false));
            }
          });
      });
    }
    return result.asObservable();
  }
  getNamesOfTexts(IdOrder: string): Observable<TextInfo[]> {
    const url = `${environment.apiHostUrl}/api/worker/getnamesoftext?IdOrder=${IdOrder}`;
    return this.http.get<TextInfo[]>(url);
  }

  downloadTextById(id: number): Observable<HttpResponse<Blob>> {
    const url = `${environment.apiHostUrl}/api/worker/gettextbyid?Id=${id}`;
    let headers = new HttpHeaders();
    headers = headers.append('Accept', '*/*');

    return this.http.get(url, {
      headers: headers,
      observe: 'response',
      responseType: 'blob'
    });
  }
  getNewOrders(): Observable<Order[]> {
    return this.http
      .get<Order[]>(this.URL_WORKER + '/getneworders')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Order(item.Id, item.UserId, item.Fio, item.Phone, item.Description, item.NeedEvaluation,
            item.Status));
        })
      );
  }

  getProcessingOrders(): Observable<Order[]> {
    return this.http
      .get<Order[]>(this.URL_WORKER + '/getprocessingorders')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Order(item.Id, item.UserId, item.Fio, item.Phone, item.Description, item.NeedEvaluation,
            item.Status));
        })
      );
  }

  getWorkOrders(): Observable<Order[]> {
    return this.http
      .get<Order[]>(this.URL_WORKER + '/getworkorders')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Order(item.Id, item.UserId, item.Fio, item.Phone, item.Description, item.NeedEvaluation,
            item.Status));
        })
      );
  }

  getWaitOrders(): Observable<Order[]> {
    return this.http
      .get<Order[]>(this.URL_WORKER + '/getwaitorders')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Order(item.Id, item.UserId, item.Fio, item.Phone, item.Description, item.NeedEvaluation,
            item.Status));
        })
      );
  }

  getApproveOrders(): Observable<Order[]> {
    return this.http
      .get<Order[]>(this.URL_WORKER + '/getapproveorders')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Order(item.Id, item.UserId, item.Fio, item.Phone, item.Description, item.NeedEvaluation,
            item.Status));
        })
      );
  }

  getFinishOrders(): Observable<Order[]> {
    return this.http
      .get<Order[]>(this.URL_WORKER + '/getfinishorders')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Order(item.Id, item.UserId, item.Fio, item.Phone, item.Description, item.NeedEvaluation,
            item.Status));
        })
      );
  }

  FinishOrder(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/worker/finishorder?id=${id}`;
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

  ProcessingOrder(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/worker/processingorder?id=${id}`;
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

  WaitOrder(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/worker/waitorder?id=${id}`;
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

  WorkOrder(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/worker/workorder?id=${id}`;
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
  AddMaterialOrder(newMaterial: OrderMaterial): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORKER + '/addordermaterial';

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

  getOrderMaterials(IdOrder): Observable<OrderMaterial[]> {
    const url = `${environment.apiHostUrl}/api/worker/getordermaterials?IdOrder=${IdOrder}`;
    return this.http
      .get<OrderMaterial[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new OrderMaterial(item.Id, item.IdMaterial, item.Material,
            item.IdOrder, item.Amount, item.Cost));
        })
      );
  }

  DeleteOrderMaterial(Id: string): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const url = `${environment.apiHostUrl}/api/worker/delordermaterial?Id=${Id}`;

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

  AddWorkTypeOrder(newWorkType: OrderWorkType): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORKER + '/addorderworktype';

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

  getOrderWorkTypes(IdOrder): Observable<OrderWorkType[]> {
    const url = `${environment.apiHostUrl}/api/worker/getorderworktypes?IdOrder=${IdOrder}`;
    return this.http
      .get<OrderWorkType[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new OrderWorkType(item.Id, item.IdWorkType, item.WorkType,
            item.IdOrder,item.Amount, item.Cost));
        })
      );
  }

  DeleteOrderWorkType(Id: string): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const url = `${environment.apiHostUrl}/api/worker/delorderworktype?Id=${Id}`;

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
  AddWorkerCost(newWorkerCost: WorkerCost): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORKER + '/addworkercost';

    this.http.post(urlDoc, newWorkerCost).subscribe(
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

  getWorkerCostsSum(IdOrder): Observable<number> {
    const url = `${environment.apiHostUrl}/api/worker/getworkercostssum?IdOrder=${IdOrder}`;
    return this.http
      .get<number>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result;
        })
      );
  }
  getOneCost(IdMaterial): Observable<number> {
    const url = `${environment.apiHostUrl}/api/worker/getonecost?Id=${IdMaterial}`;
    return this.http
      .get<number>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result;
        })
      );
  }
  getOneCostWorkType(IdWorkType): Observable<number> {
    const url = `${environment.apiHostUrl}/api/worker/getonecostworktype?Id=${IdWorkType}`;
    return this.http
      .get<number>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result;
        })
      );
  }
  getOrderMaterialsSum(IdOrder): Observable<number> {
    const url = `${environment.apiHostUrl}/api/worker/getordermaterialssum?IdOrder=${IdOrder}`;
    return this.http
      .get<number>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result;
        })
      );
  }
  getOrderWorkTypesSum(IdOrder): Observable<number> {
    const url = `${environment.apiHostUrl}/api/worker/getorderworktypessum?IdOrder=${IdOrder}`;
    return this.http
      .get<number>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result;
        })
      );
  }
  getWorkerCosts(IdOrder): Observable<WorkerCost[]> {
    const url = `${environment.apiHostUrl}/api/worker/getworkercosts?IdOrder=${IdOrder}`;
    return this.http
      .get<WorkerCost[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new WorkerCost(item.Id, item.IdOrder, item.WorkersNumber, item.Cost));
        })
      );
  }

  DeleteWorkerCost(Id: string): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const url = `${environment.apiHostUrl}/api/worker/delworkercost?Id=${Id}`;

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
  AddEvaluation(evaluation: Evaluation): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORKER + '/addevaluation';

    this.http.post(urlDoc, evaluation).subscribe(
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

  getEvaluation(IdOrder): Observable<Evaluation> {
    const url = `${environment.apiHostUrl}/api/worker/getevaluation?Id=${IdOrder}`;
    return this.http
      .get<Evaluation>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result;
        })
      );
  }

  private getOptions(query: string, status: string) {
    return {
      params: new HttpParams()
        .set('UserId', query)
        .set('Status', status)
    };
  }
}
