import { AfterViewInit, Component, ViewChild, OnInit, ChangeDetectorRef } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import {ComnfirmDialogComponent} from '../comnfirm-dialog/comnfirm-dialog.component'
import {MovieFormDialogComponent} from '../movie-form-dialog/movie-form-dialog.component'

import {
  MoviesVm, MoviesClient, MovieDto, CreateMovieCommand, UpdateMovieCommand
} from '../../web-api-client';
import { HttpClient } from '@angular/common/http';
import { environment as env } from '../../../environments/environment';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit, AfterViewInit  {
  // attributes
  movies: MovieDto[] = [];
  vm: MoviesVm = new MoviesVm();
  @ViewChild(MatPaginator)
    paginator!: MatPaginator;

  public displayedColumns: string[] = ['id', 'name', 'description', 'duration'];
  public columnsToDisplay: string[] = [...this.displayedColumns, 'actions'];
  public dataSource: MatTableDataSource<MovieDto>;

  // Constructor (get all movies)
  constructor(public dialog: MatDialog,
    private ref: ChangeDetectorRef,
    private moviesClient: MoviesClient,
    private http: HttpClient
  ) {
    this.moviesClient = new MoviesClient(http,`${env.dev.serverUrl}`);
    // Init datasource
    this.dataSource = new MatTableDataSource(this.movies);
    // Get data from api
    moviesClient.get().subscribe(
      result => {
        this.vm = result;
        if (this.vm && this.vm.lists && this.vm.lists.length) {
          this.movies = this.vm.lists;
          this.dataSource = new MatTableDataSource(this.vm.lists);
        }
      },
      error => console.error(error)
    );
  }

  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  ngAfterViewInit() {
    if (this.dataSource) {
      this.dataSource.paginator = this.paginator;
    }
  }

  // Register new movie
  add() {
    // Create blank for new form
    const data = MovieDto.fromJS({
      id: 0,
      name: '',
      description: '',
      duration: ''
    });

    // Open dialog
    const dialogRef = this.dialog.open(MovieFormDialogComponent, {
      width: '600px',
      data: {type:'add', data:data}
    });

    // Handle result when close dialog.
    dialogRef.afterClosed().subscribe((result: MovieDto) => {
      if (result) {
        console.log(result);
        let movie = MovieDto.fromJS({
          id: 0,
          name: result.name,
          description: result.description,
          duration: result.duration
        });

        this.moviesClient.create(<CreateMovieCommand>{
          name: result.name,
          description: result.description,
          duration: result.duration
        }).subscribe(
          newId => {
            if (this.vm && this.vm.lists) {
              movie.id = newId;
              this.vm.lists.push(movie);
              //this.movies = this.vm.lists;
              this.dataSource = new MatTableDataSource(this.vm.lists);
              this.dialog.open(ComnfirmDialogComponent, {
                width: '400px',
                data: "Movie registered."
              });
              this.ref.detectChanges();
            }
          },
          error => {
            let errors = JSON.parse(error.response);
            console.log("Add movie error:", errors)
            this.dialog.open(ComnfirmDialogComponent, {
              width: '400px',
              data: "Register movie failed."
            });

          }
        );
      }
    });
  }

  // Update a movie
  edit(data: MovieDto) {
    const dialogRef = this.dialog.open(MovieFormDialogComponent, {
      width: '600px',
      data: {type:'edit', data:data}
    });

    dialogRef.afterClosed().subscribe((result: MovieDto) => {
      if (result && result.id) {
        this.moviesClient.update(result.id, UpdateMovieCommand.fromJS({
          id: result.id,
          name: result.name,
          description: result.description,
          duration: result.duration
        }))
          .subscribe(
            () => {
              // Reflect updated movie to movies list
              if (this.vm.lists) {
                let index = this.vm.lists.findIndex(item => item.id == result.id);
                this.vm.lists[index] = result;
                //this.movies = this.vm.lists.map(item => item);
                this.dataSource = new MatTableDataSource(this.vm.lists);
              }

              this.dialog.open(ComnfirmDialogComponent, {
                width: '400px',
                data: "Movie updated."
              });
              this.ref.detectChanges();
            },
            error => console.error(error)
          );
      }
    });
  }

  // Delete a movie from list.
  delete(id: any) {
    const dialogRef = this.dialog.open(ComnfirmDialogComponent, {
      width: '400px',
      data: "Are you sure to delete this movie?"
    });

    dialogRef.afterClosed().subscribe((result: any) => {
      if (result) {
        // this.moviesService.remove(id);
        this.moviesClient.delete(id).subscribe(
          () => {
            if (this.vm && this.vm.lists) {
              this.vm.lists = this.vm.lists.filter(t => t.id != id)
              this.movies = this.vm.lists;
              this.dialog.open(ComnfirmDialogComponent, {
                width: '400px',
                data: "Movie deleted successfully."
              });
              this.ref.detectChanges();
            }
          },
          error => console.error(error)
      );
      }
    });
  }

}
