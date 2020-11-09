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
    return this.http.get(this.prodURL + 'generos');
  }

  getLang() {
    return this.http.get(this.prodURL + 'idiomas');
  }

  getStyles() {
    return this.http.get(this.prodURL + 'estilos');
  }

  async addMovie(postData): Promise<string> {
    await this.http.post((this.prodURL + 'nuevaPeli'), postData).toPromise().then(response => {
      this.postResponse = response.toString();
    });
    return this.postResponse
  }

  getMovies(name: string) {
    return this.http.get(this.restUrl + 'busquedaPelicula/' + name);
  }

  getMovie(id: string) {
    return this.http.get(this.restUrl + 'pelicula/' + id);
  }

  getComments(id: string) {
    return this.http.get(this.restUrl + 'pelicula/comentarios/' + id);
  }

  getAllGen() {
    return this.http.get<Genero[]>(this.restUrl + "/rf/gen");
  }

  getMoviesFilter(idGen: string, comunidad: string, imdb: string, metascore: string, popularidad: string, favorito: string) {
    return this.http.get<PeliculasCalificadas[]>(this.restUrl + "/rf/get/" + idGen + "/" + comunidad + "/" + imdb + "/" + metascore + "/" + popularidad + "/" + favorito);
  }

  async updateMovie(putData): Promise<string> {
    await this.http.put((this.prodURL + 'modificar'), putData).toPromise().then(response => {
      this.putResponse = response.toString();
    });
    return this.putResponse;
  }
}
