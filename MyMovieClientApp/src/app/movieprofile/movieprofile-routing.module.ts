import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieprofileComponent } from './components/movieprofile/movieprofile.component';

const routes: Routes = [
  {path: 'movie/:id', component: MovieprofileComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MovieprofileRoutingModule { }
