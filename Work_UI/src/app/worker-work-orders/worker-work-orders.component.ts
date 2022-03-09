import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { Order } from '../order/models/order.model';
import { WorkerService } from '../shared/worker.service';

@Component({
  selector: 'app-worker-work-orders',
  templateUrl: './worker-work-orders.component.html',
  styleUrls: ['./worker-work-orders.component.css']
})
export class WorkerWorkOrdersComponent implements OnInit {

  public orders: Order[] = [];

  constructor(
    private workerService: WorkerService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService,
    private previewDialog: FilePreviewOverlayService
  ) { }

  ngOnInit() {
    this.getWorkOrders();
  }

  getWorkOrders() {
    this.workerService.getWorkOrders().toPromise().then(
      data => {
        this.orders = data;
      });
  }

  finishOrder(id) {
    this.workerService.FinishOrder(id).subscribe(
      next => {
        this.getWorkOrders();
      },
      err => {
        console.log(err);
      }
    );
  }
  orderFull(id: string) {
    localStorage.setItem('infoId', id);
    this.router.navigate(['/worker-orderfull']);
  }
  showSnackBar(message: string, typeClass: string) {
    this.snackBar.open(message, null, {
      duration: 3000,
      verticalPosition: 'top',
      horizontalPosition: 'center',
      panelClass: [typeClass]
    });
  }

}
