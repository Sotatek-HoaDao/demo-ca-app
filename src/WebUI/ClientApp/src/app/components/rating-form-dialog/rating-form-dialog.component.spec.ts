import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RatingFormDialogComponent } from './rating-form-dialog.component';

describe('RatingFormDialogComponent', () => {
  let component: RatingFormDialogComponent;
  let fixture: ComponentFixture<RatingFormDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RatingFormDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RatingFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
