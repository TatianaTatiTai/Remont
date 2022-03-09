import {Component, Inject} from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogData } from './dialog-data.interface';

@Component({
  selector: 'app-overview-dialog',
  templateUrl: './overview-dialog.component.html',
  styleUrls: ['./overview-dialog.component.css']
})
export class OverviewDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<OverviewDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}
}
