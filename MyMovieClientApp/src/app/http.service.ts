import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  restUrl = 'https://mymovierest.azurewebsites.net/';
  testUrl = 'http://localhost:63546/';

  constructor(private http: HttpClient) { }

  getMovies(name: string){
    return this.http.get(this.testUrl + 'busquedaPelicula/' + name);
  }

  getMovie(id: string){
    return this.http.get(this.testUrl + 'pelicula/' + id);
  }
}
