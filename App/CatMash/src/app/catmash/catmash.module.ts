import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CatmashRoutingModule } from './catmash-routing.module';
import { UiModule } from '../ui/ui.module';
import { VoteComponent } from './components/vote/vote.component';


@NgModule({
  declarations: [
    VoteComponent
  ],
  imports: [
    CommonModule,
    UiModule,
    CatmashRoutingModule,
  ]
})
export class CatmashModule { }
