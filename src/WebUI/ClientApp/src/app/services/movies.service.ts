import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Movie } from '../core/movie';
import { Movies } from '../mock-movies';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {
  movies$: BehaviorSubject<Movie[]> | undefined;
  movies: Array<Movie> = [];

  constructor() {
    // this.movies$ = new BehaviorSubject([]);
    this.movies = Movies;
  }
  getAll() {
    // this.movies$.next(this.movies);
    return this.movies;
  }

  add(person: Movie) {
    this.movies.push(person);
  }

  edit(movie: Movie) {
    let findElem = this.movies.find(p => p.id == movie.id);
    if (findElem) {
      findElem.name = movie.name;
      findElem.description = movie.description;
      findElem.duration = movie.duration;
    }

    // this.movies$.next(this.movies);
  }

  remove(id: number) {

    this.movies = this.movies.filter(p => {
      return p.id != id
    });

    // this.movies$.next(this.movies);
  }
}
