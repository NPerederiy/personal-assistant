import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CostControlPageComponent } from './cost-control-page.component';

describe('CostControlPageComponent', () => {
  let component: CostControlPageComponent;
  let fixture: ComponentFixture<CostControlPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CostControlPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CostControlPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
