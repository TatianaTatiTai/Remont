import { Component, Input, Inject, OnInit } from '@angular/core';

import { FilePreviewOverlayRef } from './file-preview-overlay-ref';
import { FILE_PREVIEW_DIALOG_DATA } from './file-preview-overlay.tokens';
import {DomSanitizer} from '@angular/platform-browser';

@Component({
  selector: 'app-file-preview-overlay',
  templateUrl: './file-preview-overlay.component.html',
  styleUrls: ['./file-preview-overlay.component.css']
})
export class FilePreviewOverlayComponent implements OnInit {
  pdfUrl;
  constructor(
    public dialogRef: FilePreviewOverlayRef,
    private domSanitizer: DomSanitizer,
    @Inject(FILE_PREVIEW_DIALOG_DATA) public image: any) { }

    ngOnInit() {
      this.pdfUrl = this.domSanitizer.bypassSecurityTrustResourceUrl(this.image);
  }
}
