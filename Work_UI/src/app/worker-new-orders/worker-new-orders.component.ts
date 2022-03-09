import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { Order } from '../order/models/order.model';
import { AdminService } from '../shared/admin.service';
import { WorkerService } from '../shared/worker.service';

@Component({
  selector: 'app-worker-new-orders',
  templateUrl: './worker-new-orders.component.html',
  styleUrls: ['./worker-new-orders.component.css']
})
export class WorkerNewOrdersComponent implements OnInit {
  public neworders: Order[] = [];

  constructor(
    private workerService: WorkerService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService,
    private previewDialog: FilePreviewOverlayService
  ) { }

  ngOnInit() {
    this.getNewOrders();
  }

  getNewOrders() {
    this.workerService.getNewOrders().toPromise().then(
      data => {
        this.neworders = data;
      });
  }
  processingOrder(id) {
    this.workerService.ProcessingOrder(id).subscribe(
      next => {
        this.getNewOrders();
      },
      err => {
        console.log(err);
      }
    );
  }
  showSnackBar(message: string, typeClass: string) {
    this.snackBar.open(message, null, {
      duration: 3000,
      verticalPosition: 'top',
      horizontalPosition: 'center',
      panelClass: [typeClass]
    });
  }
  evaluation(id: string) {
    localStorage.setItem('infoId', id);
    this.router.navigate(['/worker-evaluation']);
  }
}
