import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CatmashRoutingModule } from './catmash-routing.module';
import { UiModule } from '../ui/ui.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CatmashRoutingModule,
    UiModule
  ]
})
export class CatmashModule { }
