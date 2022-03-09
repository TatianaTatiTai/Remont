import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerOrdermaterialComponent } from './worker-ordermaterial.component';

describe('WorkerOrdermaterialComponent', () => {
  let component: WorkerOrdermaterialComponent;
  let fixture: ComponentFixture<WorkerOrdermaterialComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkerOrdermaterialComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerOrdermaterialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
