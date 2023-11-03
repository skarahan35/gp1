import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockGroupComponent } from './stock-group.component';

describe('StockGroupComponent', () => {
  let component: StockGroupComponent;
  let fixture: ComponentFixture<StockGroupComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StockGroupComponent]
    });
    fixture = TestBed.createComponent(StockGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
