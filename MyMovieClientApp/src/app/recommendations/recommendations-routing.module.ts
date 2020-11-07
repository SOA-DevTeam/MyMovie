import { RecommendationFilterComponent } from './components/recommendation-filter/recommendation-filter.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path : 'recommendation-filter', component: RecommendationFilterComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecommendationsRoutingModule { }
