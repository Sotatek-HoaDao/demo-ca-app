import { Component, OnInit, Inject, Optional } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MovieDto} from '../../web-api-client';
@Component({
  selector: 'app-movie-form-dialog',
  templateUrl: './movie-form-dialog.component.html',
  styleUrls: ['./movie-form-dialog.component.scss']
})
export class MovieFormDialogComponent implements OnInit {
  type: string = '';
  title: string = '';
  formInstance: FormGroup;
  constructor(
    public dialogRef: MatDialogRef<MovieFormDialogComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: {type:string, data:MovieDto}) {
      this.formInstance = new FormGroup({
        "id":  new FormControl(''),
        "name": new FormControl('', Validators.required),
        "description": new FormControl('', Validators.required),
        "duration": new FormControl('', Validators.required),
      });
      this.type = data.type;
      if (this.type ==='add') {
        this.title = 'Register Movie';
      } else {
        this.title = 'Edit Movie';
      }
      this.formInstance.setValue(data.data);
    }

  ngOnInit(): void {
  }

  save(): void {
    this.dialogRef.close(Object.assign(new MovieDto(), this.formInstance.value));
  }

}
