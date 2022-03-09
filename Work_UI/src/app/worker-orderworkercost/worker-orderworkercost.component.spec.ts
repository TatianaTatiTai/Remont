import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerOrderworkercostComponent } from './worker-orderworkercost.component';

describe('WorkerOrderworkercostComponent', () => {
  let component: WorkerOrderworkercostComponent;
  let fixture: ComponentFixture<WorkerOrderworkercostComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [WorkerOrderworkercostComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerOrderworkercostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
