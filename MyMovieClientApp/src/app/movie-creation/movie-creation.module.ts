import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MovieCreationRoutingModule } from './movie-creation-routing.module';
import { AddMovieComponent } from './components/add-movie/add-movie.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [AddMovieComponent],
  imports: [
    CommonModule,
    MovieCreationRoutingModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    AddMovieComponent
  ]
})
export class MovieCreationModule { }
