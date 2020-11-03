import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Genero } from './recommendations/models/genero';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }
  BaseURL = 'http://localhost:63546'

  getAllGen(){
    return this.http.get<Genero[]>(this.BaseURL + "/rf/gen");
  }
}
