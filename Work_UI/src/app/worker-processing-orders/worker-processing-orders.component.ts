import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { Order } from '../order/models/order.model';
import { WorkerService } from '../shared/worker.service';

@Component({
  selector: 'app-worker-processing-orders',
  templateUrl: './worker-processing-orders.component.html',
  styleUrls: ['./worker-processing-orders.component.css']
})
export class WorkerProcessingOrdersComponent implements OnInit {
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
    this.getProcessingOrders();
  }

  getProcessingOrders() {
    this.workerService.getProcessingOrders().toPromise().then(
      data => {
        this.orders = data;
      });
  }

  waitOrder(id) {
    this.workerService.WaitOrder(id).subscribe(
      next => {
        this.getProcessingOrders();
      },
      err => {
        console.log(err);
      }
    );
  }

  orderMaterial(id: string) {
    localStorage.setItem('infoId', id);
    this.router.navigate(['/worker-ordermaterial']);
  }

  orderWorkType(id: string) {
    localStorage.setItem('infoId', id);
    this.router.navigate(['/worker-orderworktype']);
  }

  orderWorkerCost(id: string) {
    localStorage.setItem('infoId', id);
    this.router.navigate(['/worker-orderworkercost']);
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
