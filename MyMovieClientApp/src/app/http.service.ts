import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }

  private devURL: string = "http://localhost:63546/";
  private prodURL: string = "https://mymovierest.azurewebsites.net/"
  create: number = -1;
  postResponse: Object;


  getGenres() {
    return this.http.get(this.devURL + 'generos');
  }

  getLang() {
    return this.http.get(this.devURL + 'idiomas');
  }

  getStyles() {
    return this.http.get(this.devURL + 'estilos');
  }

  addMovie(postData) {
    (console.log(postData));
    this.http.post((this.devURL + 'nuevaPeli'), postData).subscribe(
      res => {
        console.log(res);
        this.postResponse = res;
        this.create = res["create"];
      });
  }
}
