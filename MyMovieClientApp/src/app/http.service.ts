import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { PeliculasCalificadas } from './recommendations/models/peliculasCalificadas';
import { Genero } from './recommendations/models/genero';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  restUrl = 'https://mymovierest.azurewebsites.net/';

  constructor(private http: HttpClient) { }
  private devURL: string = "http://localhost:63546/";
  private prodURL: string = "https://mymovierest.azurewebsites.net/"
  postResponse: string;
  putResponse: string;

  getGenres() {
    return this.http.get(this.devURL + 'generos');
  }

  getLang() {
    return this.http.get(this.devURL + 'idiomas');
  }

  getStyles() {
    return this.http.get(this.devURL + 'estilos');
  }

  async addMovie(postData): Promise<string> {
    await this.http.post((this.devURL + 'nuevaPeli'), postData).toPromise().then(response => {
      this.postResponse = response.toString();
    });
    return this.postResponse
  }

  getMovies(name: string) {
    return this.http.get(this.devURL + 'busquedaPelicula/' + name);
  }

  getMovie(id: string) {
    return this.http.get(this.devURL + 'pelicula/' + id);
  }

  getComments(id: string) {
    return this.http.get(this.devURL + 'pelicula/comentarios/' + id);
  }

  getAllGen() {
    return this.http.get<Genero[]>(this.devURL + "rf/gen");
  }

  getMoviesFilter(idGen: string, comunidad: string, imdb: string, metascore: string, popularidad: string, favorito: string) {
    return this.http.get<PeliculasCalificadas[]>(this.devURL + "rf/get/" + idGen + "/" + comunidad + "/" + imdb + "/" + metascore + "/" + popularidad + "/" + favorito);
  }

  async postComment(postData): Promise<string>{
    await this.http.post((this.devURL + 'comentar'), postData).toPromise().then(response => {
      this.postResponse = response.toString();
    });
    return this.postResponse;
  }

  async putPopularity(putData): Promise<string>{
    await this.http.put((this.devURL + 'comentar'), putData).toPromise().then(response => {
      this.putResponse = response.toString();
    });
    return this.putResponse;
  }
  async updateMovie(putData): Promise<string> {
    await this.http.put((this.devURL + 'modificar'), putData).toPromise().then(response => {
      this.putResponse = response.toString();
    });
    return this.putResponse;
  }
}


