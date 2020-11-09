import { UpdateProfileComponent } from './components/update-profile/update-profile.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieprofileComponent } from './components/movieprofile/movieprofile.component';

const routes: Routes = [
  { path: 'pelicula/:id', component: MovieprofileComponent },
  { path: 'pelicula/editar/:id', component: UpdateProfileComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MovieprofileRoutingModule { }
