import { Component, OnInit } from '@angular/core';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.scss']
})
export class LoadingComponent implements OnInit {
  loadingImg =
    'https://cdn.auth0.com/blog/auth0-react-sample/assets/loading.svg';
  constructor() { }

  ngOnInit(): void {
  }

}
