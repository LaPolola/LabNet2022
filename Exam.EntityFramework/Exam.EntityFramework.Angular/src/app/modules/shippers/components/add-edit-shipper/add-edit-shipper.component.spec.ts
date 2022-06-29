import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditShipperComponent } from './add-edit-shipper.component';

describe('AddEditShipperComponent', () => {
  let component: AddEditShipperComponent;
  let fixture: ComponentFixture<AddEditShipperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditShipperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditShipperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
