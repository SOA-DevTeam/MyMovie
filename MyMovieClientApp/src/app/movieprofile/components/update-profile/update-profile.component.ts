import { Subscriber } from 'rxjs/internal/Subscriber';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrls: ['./update-profile.component.css']
})
export class UpdateProfileComponent implements OnInit {

  constructor(private http: HttpService, private formBuilder: FormBuilder, private route: ActivatedRoute) {
    //Update Movie form
    this.moviesForm = this.formBuilder.group({
      name: ['', Validators.required],
      director: ['', Validators.required],
      year: ['', Validators.required],
      genre: ['', Validators.required],
      style: ['', Validators.required],
      language: ['', Validators.required],
      fav: ['', Validators.required],
      notaMdb: ['', Validators.required],
      notaMeta: ['', Validators.required],
    })

  }
  //form variables

  moviesForm: FormGroup;
  myimage: Observable<any>;
  Notas: number[] = [0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2, 2.1, 2.2, 2.3, 2.4, 2.5, 2.6, 2.7, 2.8, 2.9, 3, 3.1, 3.2, 3.3, 3.4, 3.5, 3.6, 3.7, 3.8, 3.9, 4, 4.1, 4.2, 4.3, 4.4, 4.5, 4.6, 4.7, 4.8, 4.9, 5, 5.1, 5.2, 5.3, 5.4, 5.5, 5.6, 5.7, 5.8, 5.9, 6, 6.1, 6.2, 6.3, 6.4, 6.5, 6.6, 6.7, 6.8, 6.9, 7, 7.1, 7.2, 7.3, 7.4, 7.5, 7.6, 7.7, 7.8, 7.9, 8, 8.1, 8.2, 8.3, 8.4, 8.5, 8.6, 8.7, 8.8, 8.9, 9, 9.1, 9.2, 9.3, 9.4, 9.5, 9.6, 9.7, 9.8, 9.9, 10];
  Favs: string[] = ['Sí', 'No'];
  styles$: Object;
  genres$: Object;
  langs$: Object;

  //selected data varibles
  notaMDbSelected: number;
  notaMetaSelected: number;
  imageSelected: string;
  yearSelected: number;
  nameSelected: string;
  directorSelected: string;
  styleSelected: number;
  genreSelected: number;
  langSelected: number;
  sysFav: string;
  favSelected: boolean;
  popularity: number;
  putStatus: number;
  idioma = {idIdioma: 0, idioma1 : "", pelicula : []};
  estilo = {
    idEstilo: 0,
    estilo1: "",
    pelicula: []};
  genero = {idGenero: 0,
    genero1: "",
    pelicula: [ ]
    };

  //original data
  movie: Object;
  movieID: number;
  movieFav: boolean;
  moviePop: number;
  movieYear: string;


  //component methods
  ngOnInit(): void {
    this.styles$ = this.getStyles();
    this.langs$ = this.getLangs();
    this.genres$ = this.getGenres();
    this.movie = this.getMovieData();
    this.putStatus = 0;
  }

  //getters
  getStyles(): Object[] {
    var request = Array.of(this.http.getStyles().subscribe((data) => (this.styles$ = data)));
    return request;
  }

  getGenres(): Object[] {
    var request; Array.of(this.http.getGenres().subscribe((data) => (this.genres$ = data)));
    return request;
  }

  getLangs(): Object[] {
    var request = Array.of(this.http.getLang().subscribe((data) => (this.langs$ = data)));
    return request;
  }

  getMovieData() {
    var request = Array.of(this.http.getMovie(this.route.snapshot.params['id']).subscribe(data => {
      this.movie = data;
      this.imageSelected = data[0].imagen;
      this.nameSelected = data[0].nombrePelicula;
      this.directorSelected = data[0].director;
      this.yearSelected = data[0].anoPelicula;
      this.genreSelected = data[0].genero.idGenero;
      this.langSelected = data[0].idioma.idIdioma;
      this.styleSelected = data[0].estilo.idEstilo;
      this.notaMDbSelected = data[0].notaIMDb;
      this.idioma = data[0].idioma;
      this.genero = data[0].genero;
      this.estilo = data[0].estilo;
      this.notaMetaSelected = data[0].notaMetascore;
      this.movieYear = data[0].anno;
      if(data[0].favorito == true){
        this.sysFav = "Sí";
      }else{
        this.sysFav = "No";
      }
      this.movieFav = data[0].favorito;
      this.moviePop = data[0].notaComunidad;
      this.popularity = this.moviePop;
      this.movieID = data[0].IdPelicula = this.route.snapshot.params['id'];
    }));
    return request;
  }

  getFavSelection() {
    if (this.sysFav == 'Sí') {
      this.favSelected = true;
    }
    else {
      this.favSelected = false;
    }
  }
  // Populairty index balancing
  checkFav() {
    if (this.movieFav == true && this.favSelected == false) {
      this.popularity = this.moviePop - 20;
    }
    else if (this.movieFav == false && this.favSelected == true) {
      this.popularity = this.moviePop + 20;
    }
    else {
      this.popularity = this.moviePop;
    }
  }

  checkYear() {
    if (this.movieYear != "2020" && this.yearSelected == 2020) {
      this.popularity = this.moviePop + 20;
    }
    else if (this.movieYear == "2020" && this.yearSelected != 2020) {
      this.popularity = this.moviePop - 20;
    }
    else {
      this.popularity = this.moviePop;
    }
  }

  //Check modification status
  putFailed() {
    this.putStatus = 404;
  }

  putSuccess() {
    this.putStatus = 200;
  }

  //generate request to server
  async onSubmit() {
    this.getFavSelection();
    this.checkFav();
    this.checkYear();
    var request = this.http.updateMovie({
      id: this.movieID,
      nombre: this.nameSelected,
      director: this.directorSelected,
      anno: this.yearSelected,
      genero: this.genreSelected,
      estilo: this.styleSelected,
      idioma: this.langSelected,
      mdb: this.notaMDbSelected,
      meta: this.notaMetaSelected,
      fav: this.favSelected,
      pop: this.popularity,
      imagen: this.imageSelected
    })
    if (await request == "0") {
      this.putFailed();
    }
    else {
      this.putSuccess();
    }
    this.moviesForm.reset();
  }

  //image selection logic
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

}