import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../http.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
name: string;
message: string;
movies: Object;
  
  constructor(public httpService : HttpService) { }

  ngOnInit(): void {
    
  }

  searchMovie(){
    
    const name = this.name;
    if(name == null){
      this.message="Debes introducir un nombre o parte del nombre";
    }else{
      this.message="Buscando"+name;
      this.httpService.getMovies(name).subscribe(data =>{
        this.movies=data;
        console.log(this.movies);
      });
    }
     
  }

}
