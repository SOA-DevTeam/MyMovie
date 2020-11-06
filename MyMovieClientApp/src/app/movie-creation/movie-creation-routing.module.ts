import { AddMovieComponent } from './components/add-movie/add-movie.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: "nuevaPeli", component: AddMovieComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MovieCreationRoutingModule { }
