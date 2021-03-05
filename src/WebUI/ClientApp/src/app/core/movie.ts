export class Movie {
  id: number;
  name: string;
  description: string;
  duration: number;
  constructor(id: number=0, name: string = '', description: string ='', duration: number = 0) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.duration = duration;
  }
}
