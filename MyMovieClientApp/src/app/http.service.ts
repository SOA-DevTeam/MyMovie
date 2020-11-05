import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }

  private devURL: string = "http://localhost:63546/";
  private prodURL: string = "https://mymovierest.azurewebsites.net/"
  postResponse: string;


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
}
