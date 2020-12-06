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
  commentResponse;
  putResponse: string;

  getGenres() {
    return this.http.get(this.devURL + 'info_peli/generos');
  }

  getLang() {
    return this.http.get(this.devURL + 'info_peli/idiomas');
  }

  getStyles() {
    return this.http.get(this.devURL + 'info_peli/estilos');
  }

  async addMovie(postData): Promise<string> {
    await this.http.post((this.devURL + 'peliculas/agregar'), postData).toPromise().then(response => {
      this.postResponse = response.toString();
    });
    return this.postResponse
  }

  getMovies(name: string) {
    return this.http.get(this.devURL + 'busqueda/' + name);
  }

  getMovie(id: string) {
    return this.http.get(this.devURL + 'busqueda/pelicula/' + id);
  }

  getComments(id: string) {
    return this.http.get(this.devURL + 'peliculas/comentarios/' + id);
  }

  getAllGen() {
    return this.http.get<Genero[]>(this.devURL + "info_peli/generos");
  }

  getMoviesFilter(idGen: string, comunidad: string, imdb: string, metascore: string, popularidad: string, favorito: string) {
    return this.http.get<PeliculasCalificadas[]>(this.devURL + "peliculas/rec/" + idGen + "/" + comunidad + "/" + imdb + "/" + metascore + "/" + popularidad + "/" + favorito);
  }

  async postComment(postData): Promise<any> {
    await this.http.post((this.devURL + 'peliculas/comentarios/nuevo'), postData).toPromise().then(response => {
      this.commentResponse = response;
    });
    return this.commentResponse;
  }

  async putPopularity(putData): Promise<string> {
    await this.http.put((this.devURL + 'peliculas/ind_pop'), putData).toPromise().then(response => {
      this.putResponse = response.toString();
    });
    return this.putResponse;
  }
  async updateMovie(putData): Promise<string> {
    await this.http.put((this.devURL + 'peliculas/modificar'), putData).toPromise().then(response => {
      this.putResponse = response.toString();
    });
    return this.putResponse;
  }
}


