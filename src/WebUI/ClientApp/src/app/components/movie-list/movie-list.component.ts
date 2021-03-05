import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Movies } from '../../mock-movies';
import { Movie } from '../../core/movie';
import {ComnfirmDialogComponent} from '../comnfirm-dialog/comnfirm-dialog.component'
import {MovieFormDialogComponent} from '../movie-form-dialog/movie-form-dialog.component'
@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {
  movies = Movies;
  public displayedColumns: string[] = ['id', 'name', 'description', 'duration'];
  public columnsToDisplay: string[] = [...this.displayedColumns, 'actions'];
  public dataSource: MatTableDataSource<Movie> | undefined;
  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
    this.dataSource = new MatTableDataSource<Movie>();
  }
  edit(data: Movie) {
    const dialogRef = this.dialog.open(MovieFormDialogComponent, {
      width: '400px',
      data: data
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log(result);
        // this.moviesService.edit(result);
      }
    });
  }
  delete(id: any) {
    const dialogRef = this.dialog.open(ComnfirmDialogComponent);

    dialogRef.afterClosed().subscribe((result: any) => {
      if (result) {
        // this.moviesService.remove(id);
      }
    });
  }

}
