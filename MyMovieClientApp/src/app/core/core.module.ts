import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { AppLayoutComponent } from './layouts/app-layout/app-layout.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './components/home/home.component';



@NgModule({
  declarations: [NavMenuComponent, AppLayoutComponent, HomeComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports: [
    AppLayoutComponent
  ]
})
export class CoreModule { }
