import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminWorktypeComponent } from './admin-worktype.component';

describe('AdminWorktypeComponent', () => {
  let component: AdminWorktypeComponent;
  let fixture: ComponentFixture<AdminWorktypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminWorktypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminWorktypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
