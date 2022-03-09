import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerEvaluationComponent } from './worker-evaluation.component';

describe('WorkerEvaluationComponent', () => {
  let component: WorkerEvaluationComponent;
  let fixture: ComponentFixture<WorkerEvaluationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkerEvaluationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerEvaluationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
