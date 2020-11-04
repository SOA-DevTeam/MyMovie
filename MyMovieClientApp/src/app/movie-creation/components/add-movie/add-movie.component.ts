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
  Notas: number[] = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
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
