import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieFormDialogComponent } from './movie-form-dialog.component';

describe('MovieFormDialogComponent', () => {
  let component: MovieFormDialogComponent;
  let fixture: ComponentFixture<MovieFormDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieFormDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
