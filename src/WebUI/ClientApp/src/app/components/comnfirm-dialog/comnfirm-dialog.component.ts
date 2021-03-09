import { Component, OnInit, Inject, Optional  } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-comnfirm-dialog',
  templateUrl: './comnfirm-dialog.component.html',
  styleUrls: ['./comnfirm-dialog.component.scss']
})
export class ComnfirmDialogComponent implements OnInit {
  message: string = '';
  constructor(public dialogRef: MatDialogRef<ComnfirmDialogComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public msg: string) {
      this.message = msg;
     }

  ngOnInit(): void {
  }

}
