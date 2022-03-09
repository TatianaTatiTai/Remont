import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerOrderFullComponent } from './worker-orderfull.component';

describe('WorkerOrderFullComponent', () => {
  let component: WorkerOrderFullComponent;
  let fixture: ComponentFixture<WorkerOrderFullComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [WorkerOrderFullComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerOrderFullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
