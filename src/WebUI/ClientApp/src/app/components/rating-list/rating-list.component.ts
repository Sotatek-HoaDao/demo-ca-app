import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { RatingType, RatingInputType } from '../../core/graphql';
import {Apollo, gql} from 'apollo-angular';
import { MatTableDataSource } from '@angular/material/table';
import { RatingDto } from 'src/app/web-api-client';
import { MatDialog } from '@angular/material/dialog';
import { RatingFormDialogComponent } from '../rating-form-dialog/rating-form-dialog.component';
import { ComnfirmDialogComponent } from '../comnfirm-dialog/comnfirm-dialog.component';

@Component({
  selector: 'app-rating-list',
  templateUrl: './rating-list.component.html',
  styleUrls: ['./rating-list.component.scss']
})
export class RatingListComponent implements OnInit {
  ratings:any;
  loading = true;
  error: any;
  createdRating: any;
  updatedRating: any;

  public displayedColumns: string[] = ['id', 'movieId', 'movieName', 'comment', 'ratingPoint', 'userMail'];
  public columnsToDisplay: string[] = [...this.displayedColumns, 'actions'];
  public dataSource!: MatTableDataSource<RatingType>;

  // Constructor
  constructor(public dialog: MatDialog, private ref: ChangeDetectorRef, private apollo: Apollo) { }

  // Init
  ngOnInit(): void {
    this.apollo
      .watchQuery({
        query: gql`
          query getRatings{
            ratings {
              id,
              movieId,
              movieName,
              comment,
              ratingPoint,
              userMail
            }
          }
        `,
      })
      .valueChanges.subscribe((result: any) => {
        this.ratings = result?.data?.ratings;
        this.loading = result.loading;
        this.error = result.error;
        this.dataSource = new MatTableDataSource(this.ratings);
      });
  }

  // Register new Rating
  add() {
    // Create blank for new form
    const data = RatingDto.fromJS({
      id: 0,
      movieId: '',
      movieName: '',
      comment: '',
      ratingPoint: '',
      userMail: ''
    });

    // Open dialog
    const dialogRef = this.dialog.open(RatingFormDialogComponent, {
      width: '600px',
      data: {type:'add', data:data}
    });

    // Handle result when close dialog.
    dialogRef.afterClosed().subscribe((result: RatingDto) => {
      if (result) {
        let rating = RatingDto.fromJS({
          id: 0,
          movieId: result.movieId,
          movieName: result.movieName,
          comment: result.comment,
          ratingPoint: result.ratingPoint,
          userMail: result.userMail
        });
        // let ratingToCreate = rating as RatingType;
        this.apollo.mutate({
          mutation: gql`mutation($rating: ratingInput!){
            createRating(rating: $rating){
              id,
              movieId,
              movieName,
              comment,
              ratingPoint,
              userMail
            }
          }`,
          variables: {rating: rating}
        }).subscribe((result: any) => {
          this.createdRating = <RatingType> result?.data?.createRating;
          let newarr = [this.createdRating];
          let updatearr = this.ratings.concat(newarr);
          this.dataSource = new MatTableDataSource(updatearr);
          this.dialog.open(ComnfirmDialogComponent, {
            width: '400px',
            data: "Rating added."
          });
          this.ref.detectChanges();
        })

      }
    });
  }

    // Update a rating
    edit(data: RatingType) {
      let rating = RatingDto.fromJS({
        id: data.id,
        movieId: data.movieId,
        movieName: data.movieName,
        comment: data.comment,
        ratingPoint: data.ratingPoint,
        userMail: data.userMail
      });
      console.log('input', data)
      const dialogRef = this.dialog.open(RatingFormDialogComponent, {
        width: '600px',
        data: {type:'edit', data:rating}
      });

      dialogRef.afterClosed().subscribe((result: RatingDto) => {
        if (result && result.id) {
          let updateData = RatingDto.fromJS({
            id: result.id,
            movieId: result.movieId,
            movieName: result.movieName,
            comment: result.comment,
            ratingPoint: result.ratingPoint,
            userMail: result.userMail
          });
          this.apollo.mutate({
            mutation: gql`mutation($rating: ratingInput!){
              updateRating(rating: $rating){
                id,
                movieId,
                movieName,
                comment,
                ratingPoint,
                userMail
              }
            }`,
            variables: {rating: updateData}
          }).subscribe((result:any) => {
            this.updatedRating = result?.data?.updateRating;
            let index = this.ratings.findIndex((item:RatingType) => item.id == this.updatedRating.id);
            this.ratings[index] = this.updatedRating;
            this.dataSource = new MatTableDataSource(this.ratings);
            this.dialog.open(ComnfirmDialogComponent, {
                width: '400px',
                data: "Rating updated."
              });
            this.ref.detectChanges();
          });
        }
      });
    }

    // Delete rating from list.
    delete(id: any) {
      const dialogRef = this.dialog.open(ComnfirmDialogComponent, {
        width: '400px',
        data: "Are you sure to delete this rating?"
      });

      dialogRef.afterClosed().subscribe((result: any) => {
        if (result) {
          this.apollo.mutate({
            mutation: gql`mutation($ratingId: ID!){
              deleteRating(ratingId: $ratingId)
             }`,
            variables: { ratingId: id}
          }).subscribe(res => {
            let updatedArr = this.ratings.filter((item:RatingType) => item.id != id);
            this.dataSource = new MatTableDataSource(updatedArr);
            this.dialog.open(ComnfirmDialogComponent, {
                width: '400px',
                data: "Rating deleted."
              });
            this.ref.detectChanges();
          })
        }
      });
    }

}
