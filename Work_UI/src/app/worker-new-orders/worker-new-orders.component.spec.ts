import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerNewOrdersComponent } from './worker-new-orders.component';

describe('WorkerNewOrdersComponent', () => {
  let component: WorkerNewOrdersComponent;
  let fixture: ComponentFixture<WorkerNewOrdersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [WorkerNewOrdersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerNewOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
