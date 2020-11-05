import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MovieprofileRoutingModule } from './movieprofile-routing.module';
import { MovieprofileComponent } from './movieprofile/movieprofile.component';


@NgModule({
  declarations: [MovieprofileComponent],
  imports: [
    CommonModule,
    MovieprofileRoutingModule
  ]
})
export class MovieprofileModule { }
