import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }

  private devURL: string = "http://localhost:63546/";
  private prodURL: string = "https://mymovierest.azurewebsites.net/"


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
    this.http.post("http://httpbin.org/post", postData).toPromise().then((data: any) => {
      console.log(data)
    });

  }
}
