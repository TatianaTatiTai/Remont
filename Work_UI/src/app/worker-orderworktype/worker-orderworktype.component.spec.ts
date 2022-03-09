import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerOrderworktypeComponent } from './worker-orderworktype.component';

describe('WorkerOrderworktypeComponent', () => {
  let component: WorkerOrderworktypeComponent;
  let fixture: ComponentFixture<WorkerOrderworktypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [WorkerOrderworktypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerOrderworktypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
