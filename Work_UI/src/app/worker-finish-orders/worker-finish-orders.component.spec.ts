import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerFinishOrdersComponent } from './worker-finish-orders.component';

describe('WorkerFinishOrdersComponent', () => {
  let component: WorkerFinishOrdersComponent;
  let fixture: ComponentFixture<WorkerFinishOrdersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [WorkerFinishOrdersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerFinishOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
