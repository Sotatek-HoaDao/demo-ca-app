import { Component, OnInit } from '@angular/core';
import { Ratings } from '../../mock-ratings';

@Component({
  selector: 'app-rating-list',
  templateUrl: './rating-list.component.html',
  styleUrls: ['./rating-list.component.scss']
})
export class RatingListComponent implements OnInit {
  ratings = Ratings;
  constructor() { }

  ngOnInit(): void {
  }

}
