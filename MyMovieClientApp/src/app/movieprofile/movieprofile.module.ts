import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MovieprofileRoutingModule } from './movieprofile-routing.module';
import { MovieprofileComponent } from './components/movieprofile/movieprofile.component';
import { UpdateProfileComponent } from './components/update-profile/update-profile.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [MovieprofileComponent, UpdateProfileComponent],
  imports: [
    CommonModule,
    MovieprofileRoutingModule,
    FormsModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
  ], exports: [
    MovieprofileComponent
  ]
})
export class MovieprofileModule { }
