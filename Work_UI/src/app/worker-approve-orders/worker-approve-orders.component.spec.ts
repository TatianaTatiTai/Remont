import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerApproveOrdersComponent } from './worker-approve-orders.component';

describe('WorkerApproveOrdersComponent', () => {
  let component: WorkerApproveOrdersComponent;
  let fixture: ComponentFixture<WorkerApproveOrdersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkerApproveOrdersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerApproveOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
