import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../http.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  // Movie name updated with the input
  name: string;
  // Message displayed when input is not right
  message: string;
  // Object with movies data from the get method
  // tslint:disable-next-line: ban-types
  movies: Object;


  constructor(public httpService: HttpService) { }

  ngOnInit(): void {

  }
  // Http method to get movies
  // tslint:disable-next-line: typedef
  searchMovie(){

    const name = this.name;
    this.message = '';
    this.httpService.getMovies(name).subscribe(data => {
        this.movies = data;
        console.log(this.movies);
      });
  }

}