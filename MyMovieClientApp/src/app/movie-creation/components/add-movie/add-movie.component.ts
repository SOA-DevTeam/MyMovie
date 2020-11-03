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
      // genre: ['', Validators.required],
      //style: ['', Validators.required],
      //language: ['', Validators.required],
      notaMdb: ['', Validators.required],
      notaMeta: ['', Validators.required],

    })
  }

  myimage: Observable<any>;
  Notas: number[] = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
  moviesForm: FormGroup;
  styles$: Object;
  genres$: Object;
  langs$: Object;
  notaMDbSelected: number;
  notaMetaSelected: number;
  imageSelected: string = "";
  yearSelected: number;
  nameSelected: string;
  directorSelected: string;
  styleSelected: number;
  genreSelected: number;
  langSelected: number;
  sysFav = 0;
  popularity = 0;


  onChange($event: Event) {
    const file = ($event.target as HTMLInputElement).files[0];
    this.convertToBase64(file);
  }

  convertToBase64(file: File) {
    this.myimage = new Observable((subscriber: Subscriber<any>) => {
      this.readFile(file, subscriber);
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
    console.log(this.nameSelected)
    console.log(this.directorSelected);
    console.log(this.yearSelected)
    console.log(this.notaMDbSelected)
    console.log(this.notaMetaSelected)
    console.log(this.sysFav)
    if (this.yearSelected == 2020) {
      this.popularity = this.popularity + 20
    }
    console.log(this.popularity)
  }


  ngOnInit(): void {
  }

}
