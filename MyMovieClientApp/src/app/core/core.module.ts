import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { AppLayoutComponent } from './layouts/app-layout/app-layout.component';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [NavMenuComponent, AppLayoutComponent],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  exports: [
    AppLayoutComponent
  ]
})
export class CoreModule { }
