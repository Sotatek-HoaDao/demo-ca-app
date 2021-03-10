import { Component,  OnInit, Inject, Optional } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RatingType } from 'src/app/core/graphql';
import { RatingDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-rating-form-dialog',
  templateUrl: './rating-form-dialog.component.html',
  styleUrls: ['./rating-form-dialog.component.scss']
})
export class RatingFormDialogComponent implements OnInit {
  type: string = '';
  title: string = '';
  formInstance: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<RatingFormDialogComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: {type:string, data:RatingDto}) {
      this.formInstance = new FormGroup({
        "id":  new FormControl(''),
        "movieId": new FormControl('', Validators.required),
        "movieName": new FormControl('', Validators.required),
        "comment": new FormControl('', Validators.required),
        "ratingPoint": new FormControl('', Validators.required),
        "userMail": new FormControl('', Validators.required),
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
    this.dialogRef.close(Object.assign(new RatingDto(), this.formInstance.value));
  }

}
