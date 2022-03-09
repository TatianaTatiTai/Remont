import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatToolbarModule, MatSidenavModule, MatIconModule,
   MatListModule, MAT_DATE_LOCALE } from '@angular/material';
import { MaterialModule } from './modules/material/material.module';
import { FileDropModule } from 'ngx-file-drop';

import { RecaptchaModule } from 'ng-recaptcha';
import { RecaptchaFormsModule } from 'ng-recaptcha/forms';
import { NgxSpinnerModule } from 'ngx-spinner';

import { UserService } from './shared/user.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sing-in/sing-in.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { OverviewDialogComponent } from './overview-dialog/overview-dialog.component';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { OverlayModule } from '@angular/cdk/overlay';
import { FilePreviewOverlayComponent } from './file-preview/file-preview-overlay/file-preview-overlay.component';
import { DatePipe } from '@angular/common';
import { RegisterComponent } from './user/register/register.component';
import { AdminNavComponent } from './admin-nav/admin-nav.component';
import { AdminService } from './shared/admin.service';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { UserFormComponent } from './user-form/user-form.component';
import { WorkerService } from './shared/worker.service';
import { DateTimeFormatPipe } from './pipes/date-time-format.pipe';
import { DateFormatPipe } from './pipes/date-format.pipe';
import { WorkerHomeComponent } from './worker-home/worker-home.component';
import { WorkerNavComponent } from './worker-nav/worker-nav.component';
import { WorkerRegistrationComponent } from './worker-registration/worker-registration.component';
import { OrderComponent } from './order/order.component';
import { MyOrderComponent } from './my-order/my-order.component';
import { WorkerNewOrdersComponent } from './worker-new-orders/worker-new-orders.component';
import { WorkerProcessingOrdersComponent } from './worker-processing-orders/worker-processing-orders.component';
import { WorkerWorkOrdersComponent } from './worker-work-orders/worker-work-orders.component';
import { WorkerApproveOrdersComponent } from './worker-approve-orders/worker-approve-orders.component';
import { WorkerWaitOrdersComponent } from './worker-wait-orders/worker-wait-orders.component';
import { AdminMaterialComponent } from './admin-material/admin-material.component';
import { AdminWorktypeComponent } from './admin-worktype/admin-worktype.component';
import { WorkerOrdermaterialComponent } from './worker-ordermaterial/worker-ordermaterial.component';
import { WorkerOrderworktypeComponent } from './worker-orderworktype/worker-orderworktype.component';
import { WorkerFinishOrdersComponent } from './worker-finish-orders/worker-finish-orders.component';
import { WorkerOrderworkercostComponent } from './worker-orderworkercost/worker-orderworkercost.component';
import { WorkerOrderFullComponent } from './worker-orderfull/worker-orderfull.component';
import { UserOrderFullComponent } from './user-orderfull/user-orderfull.component';
import { WorkerEvaluationComponent } from './worker-evaluation/worker-evaluation.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    SignInComponent,
    RegisterComponent,
    HomeComponent,
    WorkerHomeComponent,
    AdminHomeComponent,
    AdminUsersComponent,
    OverviewDialogComponent,
    MainNavComponent,
    UserFormComponent,
    DateTimeFormatPipe,
    DateFormatPipe,
    WorkerNavComponent,
    AdminNavComponent,
    WorkerRegistrationComponent,
    FilePreviewOverlayComponent,
    OrderComponent,
    MyOrderComponent,
    WorkerNewOrdersComponent,
    WorkerProcessingOrdersComponent,
    WorkerWorkOrdersComponent,
    WorkerApproveOrdersComponent,
    WorkerWaitOrdersComponent,
    AdminMaterialComponent,
    AdminWorktypeComponent,
    WorkerOrdermaterialComponent,
    WorkerOrderworktypeComponent,
    WorkerOrderworkercostComponent,
    WorkerFinishOrdersComponent,
    WorkerOrderFullComponent,
    UserOrderFullComponent,
    WorkerEvaluationComponent,
  ],
  entryComponents: [
    OverviewDialogComponent,
    FilePreviewOverlayComponent
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatButtonModule,
    MatCheckboxModule,
    FileDropModule,
    RecaptchaModule,
    RecaptchaFormsModule,
    NgxSpinnerModule,
    LayoutModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    OverlayModule
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'ru-RU' },
    DatePipe,
    UserService,
    AdminService,
    WorkerService,
    ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {}
}
