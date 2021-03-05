import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComnfirmDialogComponent } from './comnfirm-dialog.component';

describe('ComnfirmDialogComponent', () => {
  let component: ComnfirmDialogComponent;
  let fixture: ComponentFixture<ComnfirmDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComnfirmDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComnfirmDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
