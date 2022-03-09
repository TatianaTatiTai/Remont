import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserOrderFullComponent } from './user-orderfull.component';

describe('UserOrderFullComponent', () => {
  let component: UserOrderFullComponent;
  let fixture: ComponentFixture<UserOrderFullComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [UserOrderFullComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserOrderFullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
