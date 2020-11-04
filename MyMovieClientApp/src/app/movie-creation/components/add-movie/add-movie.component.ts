import { JsonPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Subscriber } from 'rxjs/internal/Subscriber';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.css']
})
export class AddMovieComponent implements OnInit {

  constructor(private http: HttpService, private formBuilder: FormBuilder) {
    this.moviesForm = this.formBuilder.group({
      name: ['', Validators.required],
      director: ['', Validators.required],
      year: ['', Validators.required],
      genre: ['', Validators.required],
      style: ['', Validators.required],
      language: ['', Validators.required],
      notaMdb: ['', Validators.required],
      notaMeta: ['', Validators.required],

    })
  }

  myimage: Observable<any>;
  Notas: number[] = [0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2, 2.1, 2.2, 2.3, 2.4, 2.5, 2.6, 2.7, 2.8, 2.9, 3, 3.1, 3.2, 3.3, 3.4, 3.5, 3.6, 3.7, 3.8, 3.9, 4, 4.1, 4.2, 4.3, 4.4, 4.5, 4.6, 4.7, 4.8, 4.9, 5, 5.1, 5.2, 5.3, 5.4, 5.5, 5.6, 5.7, 5.8, 5.9, 6, 6.1, 6.2, 6.3, 6.4, 6.5, 6.6, 6.7, 6.8, 6.9, 7, 7.1, 7.2, 7.3, 7.4, 7.5, 7.6, 7.7, 7.8, 7.9, 8, 8.1, 8.2, 8.3, 8.4, 8.5, 8.6, 8.7, 8.8, 8.9, 9, 9.1, 9.2, 9.3, 9.4, 9.5, 9.6, 9.7, 9.8, 9.9, 10];
  moviesForm: FormGroup;
  styles$: any;
  genres$: Object;
  langs$: Object;
  notaMDbSelected: number;
  notaMetaSelected: number;
  imageSelected: string;
  yearSelected: number;
  nameSelected: string;
  directorSelected: string;
  styleSelected: number;
  genreSelected: number;
  langSelected: number;
  sysFav = false;
  popularity = 0;



  onChange($event: Event) {
    const file = ($event.target as HTMLInputElement).files[0];
    this.convertToBase64(file);
  }

  convertToBase64(file: File) {
    this.myimage = new Observable((subscriber: Subscriber<any>) => {
      this.readFile(file, subscriber);
    });

    const observable = new Observable((subscriber: Subscriber<any>) => { this.readFile(file, subscriber) });
    observable.subscribe((d) => {
      this.imageSelected = d;
    });
  }

  readFile(file: File, subscriber: Subscriber<any>) {
    const filereader = new FileReader();
    filereader.readAsDataURL(file);

    filereader.onload = () => {
      subscriber.next(filereader.result);
      subscriber.complete();
    };
    filereader.onerror = (error) => {
      subscriber.error(error);
      subscriber.complete();
    };
  }

  onSubmit() {
    if (this.yearSelected == 2020) {
      this.popularity = this.popularity + 20
    }
    this.http.addMovie({
      nombre: this.nameSelected,
      director: this.directorSelected,
      anno: this.yearSelected,
      genero: this.genreSelected,
      estilo: this.styleSelected,
      idioma: this.langSelected,
      mdb: this.notaMDbSelected,
      meta: this.notaMetaSelected,
      fav: this.sysFav,
      pop: this.popularity,
      imagen: this.imageSelected
    })
  }


  ngOnInit(): void {

    this.imageSelected = "";
    this.popularity = 0;
    this.styles$ = Array.of(this.http.getStyles().subscribe((data) => (this.styles$ = data)));
    this.langs$ = Array.of(this.http.getLang().subscribe((data) => (this.langs$ = data)));
    this.genres$ = Array.of(this.http.getGenres().subscribe((data) => (this.genres$ = data)));
  }

}
