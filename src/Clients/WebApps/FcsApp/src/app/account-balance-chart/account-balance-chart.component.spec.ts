import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountBalanceChartComponent } from './account-balance-chart.component';

describe('AccountBalanceChartComponent', () => {
  let component: AccountBalanceChartComponent;
  let fixture: ComponentFixture<AccountBalanceChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountBalanceChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountBalanceChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
