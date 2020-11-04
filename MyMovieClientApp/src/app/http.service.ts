import { PeliculasCalificadas } from './recommendations/models/peliculasCalificadas';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Genero } from './recommendations/models/genero';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }
  BaseURL = 'https://mymovierest.azurewebsites.net/';

  getAllGen(){
    return this.http.get<Genero[]>(this.BaseURL + "/rf/gen");
  }

  getMoviesFilter(idGen : string, comunidad : string, imdb : string, metascore : string, popularidad : string, favorito : string){
    return this.http.get<PeliculasCalificadas[]>(this.BaseURL + "/rf/get/" + idGen + "/" + comunidad + "/" + imdb + "/" + metascore + "/" + popularidad + "/" + favorito);
  }
}
