import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RecommendationsRoutingModule } from './recommendations-routing.module';
import { RecommendationFilterComponent } from './components/recommendation-filter/recommendation-filter.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [RecommendationFilterComponent],
  imports: [
    CommonModule,
    RecommendationsRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [RecommendationFilterComponent]
})
export class RecommendationsModule { }
