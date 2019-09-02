import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncomeControlPageComponent } from './income-control-page.component';

describe('IncomeControlPageComponent', () => {
  let component: IncomeControlPageComponent;
  let fixture: ComponentFixture<IncomeControlPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncomeControlPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncomeControlPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
