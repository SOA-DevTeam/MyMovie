import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { HttpClientModule } from '@angular/common/http';
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
    SearchModule,
    MovieprofileModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
