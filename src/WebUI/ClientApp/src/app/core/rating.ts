export class Rating {
  id: number;
  movie_id: number;
  movie_name: string;
  comment: string;
  point: number;
  user_mail: string;
  constructor (id:number = 0, movie_id:number = 0, movie_name:string = '', comment:string='', point:number=0, user_mail:string = '') {
    this.id = id;
    this.movie_id = movie_id;
    this.movie_name = movie_name;
    this.comment = comment;
    this.point = point;
    this.user_mail = user_mail; // rating person
  }
}
