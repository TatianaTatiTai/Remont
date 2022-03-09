import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerProcessingOrdersComponent } from './worker-processing-orders.component';

describe('WorkerProcessingOrdersComponent', () => {
  let component: WorkerProcessingOrdersComponent;
  let fixture: ComponentFixture<WorkerProcessingOrdersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkerProcessingOrdersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerProcessingOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
