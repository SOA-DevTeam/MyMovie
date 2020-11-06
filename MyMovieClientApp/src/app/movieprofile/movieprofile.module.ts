import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MovieprofileRoutingModule } from './movieprofile-routing.module';
import { MovieprofileComponent } from './components/movieprofile/movieprofile.component';


@NgModule({
  declarations: [MovieprofileComponent],
  imports: [
    CommonModule,
    MovieprofileRoutingModule,
    FormsModule
  ], exports : [
    MovieprofileComponent
  ]
})
export class MovieprofileModule { }
