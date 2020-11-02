import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { AppLayoutComponent } from './layouts/app-layout/app-layout.component';



@NgModule({
  declarations: [NavMenuComponent, AppLayoutComponent],
  imports: [
    CommonModule
  ],
  exports: [
    AppLayoutComponent
  ]
})
export class CoreModule { }
