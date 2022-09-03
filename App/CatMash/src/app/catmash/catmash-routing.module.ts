import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from '../ui/pages/layout/layout.component';
import { VoteComponent } from './components/vote/vote.component';

const routes: Routes = [
  {
    path: 'catmash',
    component: LayoutComponent,
    children: [
      {
        path: 'vote',
        component: VoteComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatmashRoutingModule { }
