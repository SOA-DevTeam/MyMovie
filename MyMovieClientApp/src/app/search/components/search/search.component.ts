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
  // Object with movies data from the get method
  // tslint:disable-next-line: ban-types
  movies: Object;

  loading: boolean;


  constructor(public httpService: HttpService) { }

  ngOnInit(): void {

  }
  // Http method to get movies
  // tslint:disable-next-line: typedef
  searchMovie(){
    const name = this.name;
    if (name.length > 4){
      this.loading = true;
      this.httpService.getMovies(name).subscribe(data => {
      this.movies = data;
      this.loading = false;
    });
    }
  }

}
