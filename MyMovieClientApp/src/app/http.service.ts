import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  searchUrl = 'http://localhost:63546/api/busqueda/';

  constructor(private http: HttpClient) { }

  getMovies(name: string){
    return this.http.get(this.searchUrl + name);
  }
}
