import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { HttpClientModule } from '@angular/common/http';
import { MovieCreationModule } from './movie-creation/movie-creation.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchModule } from './search/search.module';
import { MovieprofileModule } from './movieprofile/movieprofile.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    HttpClientModule,
    MovieCreationModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    SearchModule,
    MovieprofileModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
