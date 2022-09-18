import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CatmashRoutingModule } from './catmash-routing.module';
import { UiModule } from '../ui/ui.module';
import { VoteComponent } from './components/vote/vote.component';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { LeaderboardComponent } from './pages/leaderboard/leaderboard.component';
import { CatCardComponent } from './components/cat-card/cat-card.component';


@NgModule({
  declarations: [
    VoteComponent,
    LeaderboardComponent,
    CatCardComponent
  ],
  imports: [
    CommonModule,
    UiModule,
    NzCardModule,
    NzButtonModule,
    CatmashRoutingModule,
  ]
})
export class CatmashModule { }
