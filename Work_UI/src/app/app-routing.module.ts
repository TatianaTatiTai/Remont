import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sing-in/sing-in.component';
import { RegisterComponent } from './user/register/register.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { UserFormComponent } from './user-form/user-form.component';
import { WorkerHomeComponent } from './worker-home/worker-home.component';
import { WorkerRegistrationComponent } from './worker-registration/worker-registration.component';
import { OrderComponent } from './order/order.component';
import { MyOrderComponent } from './my-order/my-order.component';
import { WorkerNewOrdersComponent } from './worker-new-orders/worker-new-orders.component';
import { WorkerProcessingOrdersComponent } from './worker-processing-orders/worker-processing-orders.component';
import { WorkerWaitOrdersComponent } from './worker-wait-orders/worker-wait-orders.component';
import { WorkerApproveOrdersComponent } from './worker-approve-orders/worker-approve-orders.component';
import { WorkerWorkOrdersComponent } from './worker-work-orders/worker-work-orders.component';
import { AdminMaterialComponent } from './admin-material/admin-material.component';
import { AdminWorktypeComponent } from './admin-worktype/admin-worktype.component';
import { WorkerOrdermaterialComponent } from './worker-ordermaterial/worker-ordermaterial.component';
import { WorkerOrderworktypeComponent } from './worker-orderworktype/worker-orderworktype.component';
import { WorkerFinishOrdersComponent } from './worker-finish-orders/worker-finish-orders.component';
import { WorkerOrderworkercostComponent } from './worker-orderworkercost/worker-orderworkercost.component';
import { WorkerOrderFullComponent } from './worker-orderfull/worker-orderfull.component';
import { UserOrderFullComponent } from './user-orderfull/user-orderfull.component';
import { WorkerEvaluationComponent } from './worker-evaluation/worker-evaluation.component';

const routes: Routes = [
  { path : '', redirectTo: '/login', pathMatch : 'full'},
  { path: 'home', component: HomeComponent },
  { path: 'order', component: OrderComponent },
  { path: 'my-orders', component: MyOrderComponent },
  { path: 'worker-home', component: WorkerHomeComponent },
  { path: 'worker-new-orders', component: WorkerNewOrdersComponent },
  { path: 'worker-evaluation', component: WorkerEvaluationComponent },
  { path: 'worker-processing-orders', component: WorkerProcessingOrdersComponent },
  { path: 'worker-wait-orders', component: WorkerWaitOrdersComponent },
  { path: 'worker-approve-orders', component: WorkerApproveOrdersComponent },
  { path: 'worker-work-orders', component: WorkerWorkOrdersComponent },
  { path: 'worker-finish-orders', component: WorkerFinishOrdersComponent },
  { path: 'worker-ordermaterial', component: WorkerOrdermaterialComponent },
  { path: 'worker-orderworktype', component: WorkerOrderworktypeComponent },
  { path: 'worker-orderworkercost', component: WorkerOrderworkercostComponent },
  { path: 'worker-orderfull', component: WorkerOrderFullComponent },
  { path: 'user-orderfull', component: UserOrderFullComponent },
  { path: 'admin-home', component: AdminHomeComponent },
  { path: 'admin-users', component: AdminUsersComponent },
  { path: 'admin-materials', component: AdminMaterialComponent },
  { path: 'admin-worktypes', component: AdminWorktypeComponent },

  { path: 'worker-registration', component: WorkerRegistrationComponent },
  { path: 'login', component: UserComponent, children: [{ path: '', component: SignInComponent }]},
  { path: 'login', component: UserComponent, pathMatch: 'full' },
  { path: 'registration', component: RegisterComponent, pathMatch: 'full' },
  { path: 'user-form', component: UserFormComponent },
  { path: '**', redirectTo: '/login'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
