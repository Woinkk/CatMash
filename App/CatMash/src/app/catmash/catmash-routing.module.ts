import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from '../ui/pages/layout/layout.component';
import { VoteComponent } from './components/vote/vote.component';
import { LeaderboardComponent } from './pages/leaderboard/leaderboard.component';

const routes: Routes = [
  {
    path: 'catmash',
    component: LayoutComponent,
    children: [
      {
        path: 'vote',
        component: VoteComponent
      },
      {
        path: 'leaderboard',
        component: LeaderboardComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatmashRoutingModule { }
