import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponentComponent } from './layout-component/layout-component.component';
import { LayoutComponent } from './pages/layout/layout.component';



@NgModule({
  declarations: [
    LayoutComponentComponent,
    LayoutComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    LayoutComponentComponent,
    LayoutComponent
  ]
})
export class UiModule { }
