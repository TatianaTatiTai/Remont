import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerWaitOrdersComponent } from './worker-wait-orders.component';

describe('WorkerWaitOrdersComponent', () => {
  let component: WorkerWaitOrdersComponent;
  let fixture: ComponentFixture<WorkerWaitOrdersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkerWaitOrdersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerWaitOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
