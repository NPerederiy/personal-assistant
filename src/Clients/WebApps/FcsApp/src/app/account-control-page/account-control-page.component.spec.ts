import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountControlPageComponent } from './account-control-page.component';

describe('AccountControlPageComponent', () => {
  let component: AccountControlPageComponent;
  let fixture: ComponentFixture<AccountControlPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountControlPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountControlPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
