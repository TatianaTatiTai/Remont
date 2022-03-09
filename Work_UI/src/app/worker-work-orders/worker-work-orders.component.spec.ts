import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerWorkOrdersComponent } from './worker-work-orders.component';

describe('WorkerWorkOrdersComponent', () => {
  let component: WorkerWorkOrdersComponent;
  let fixture: ComponentFixture<WorkerWorkOrdersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkerWorkOrdersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerWorkOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
