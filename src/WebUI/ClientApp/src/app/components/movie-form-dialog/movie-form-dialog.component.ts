import { Component, OnInit, Inject, Optional } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Movie } from 'src/app/core/movie';

@Component({
  selector: 'app-movie-form-dialog',
  templateUrl: './movie-form-dialog.component.html',
  styleUrls: ['./movie-form-dialog.component.scss']
})
export class MovieFormDialogComponent implements OnInit {
  formInstance: FormGroup;
  constructor(
    public dialogRef: MatDialogRef<MovieFormDialogComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: Movie) {
      this.formInstance = new FormGroup({
        "id":  new FormControl('', Validators.required),
        "name": new FormControl('', Validators.required),
        "description": new FormControl('', Validators.required),
        "duration": new FormControl('', Validators.required),
      });

      this.formInstance.setValue(data);
    }

  ngOnInit(): void {
  }

  save(): void {
    this.dialogRef.close(Object.assign(new Movie(), this.formInstance.value));
  }

}
