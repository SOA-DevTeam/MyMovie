import { PeliculasCalificadas } from './../../models/peliculasCalificadas';
import { HttpService } from './../../../http.service';
import { Component, OnInit} from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Genero } from '../../models/genero';

@Component({
  selector: 'app-recommendation-filter',
  templateUrl: './recommendation-filter.component.html',
  styleUrls: ['./recommendation-filter.component.css'],
})
export class RecommendationFilterComponent implements OnInit {

  constructor(private http: HttpClient, private httpS : HttpService) 
  {

  }

    
  imdb : number = 0;
  
  popularity : number = 0;
  
  community : number = 0;
  
  platform : number = 0;
  
  metascore : number = 0;
  
  total : number = 100;

  goodT : number = -1;

  goodF : number = -1;

  generos : Genero[];

  genero : number;

  peliculas : PeliculasCalificadas[];

  ngOnInit(): void {
      this.httpS.getAllGen().subscribe(result => {
        this.generos = result;
      }, error => console.error(error));
  }



  calculateTotal(item){
    console.log(this.total);
    this.total = 100 - this.imdb - this.popularity - this.community - this.metascore - this.platform;
    this.validate();
  }

  validate(){
    if(this.total < 0){
      this.goodT = 1;
    }else{
      this.goodT = -1;
      console.log(this.total);
    }

    }

  filter(event){
    if(this.goodT == 1){
      this.goodF = 1;
      console.log(this.genero);
    }else{
      this.goodF = -1;
      this.httpS.getMoviesFilter(this.genero.toString(),
      this.community.toString(), 
      this.imdb.toString(),
      this.metascore.toString(),
      this.popularity.toString(), 
      this.platform.toString()).subscribe(result => {
        this.peliculas = result;
      }, error => console.error());
    }
  }

}
