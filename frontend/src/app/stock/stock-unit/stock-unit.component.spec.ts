import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockUnitComponent } from './stock-unit.component';

describe('StockUnitComponent', () => {
  let component: StockUnitComponent;
  let fixture: ComponentFixture<StockUnitComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StockUnitComponent]
    });
    fixture = TestBed.createComponent(StockUnitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
