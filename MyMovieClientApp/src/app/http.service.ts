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
}
