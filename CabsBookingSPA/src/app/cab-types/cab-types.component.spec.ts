import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CabTypesComponent } from './cab-types.component';

describe('CabTypesComponent', () => {
  let component: CabTypesComponent;
  let fixture: ComponentFixture<CabTypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CabTypesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CabTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
