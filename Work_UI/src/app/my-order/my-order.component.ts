import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Local } from 'protractor/built/driverProviders';
import { FilePreviewOverlayService } from '../file-preview/file-preview-overlay.service';
import { Order } from '../order/models/order.model';
import { OrderService } from '../order/service/order.service';
import { OverviewDialogComponent } from '../overview-dialog/overview-dialog.component';

@Component({
  selector: 'app-my-order',
  templateUrl: './my-order.component.html',
  styleUrls: ['./my-order.component.css']
})
export class MyOrderComponent implements OnInit {

  public orders: Order[] = [];

  successDelMessage = 'Заказ удален успешно.';
  errorMessage = 'Вы можете удалить только новую заявку.';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private orderService: OrderService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService,
    private previewDialog: FilePreviewOverlayService
  ) { }

  ngOnInit() {
    this.getOrders();
  }

  getOrders() {
    let UserId = localStorage.getItem('userId');
    this.orderService.getMyOrders(UserId).toPromise().then(
      data => {
        this.orders = data;
      });
  }

  deleteOrder(Id: string, Status: string) {
    this.orderService.DeleteOrder(Id).subscribe(next => {
      this.spinner.hide();
      if (next.error === false) {
        this.showSnackBar(this.successDelMessage, this.successStyle);
        this.getOrders();
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

  approveOrder(id) {
    this.orderService.ApproveOrder(id).subscribe(
      next => {
        this.getOrders();
      },
      err => {
        console.log(err);
      }
    );
  }
  rejectOrder(id) {
    this.orderService.RejectOrder(id).subscribe(
      next => {
        this.getOrders();
      },
      err => {
        console.log(err);
      }
    );
  }
  orderFull(id: string) {
    localStorage.setItem('infoId', id);
    this.router.navigate(['/user-orderfull']);
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
