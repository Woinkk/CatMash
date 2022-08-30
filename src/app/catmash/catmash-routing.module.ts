import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from '../ui/pages/layout/layout.component';

const routes: Routes = [
  {
    path: 'catmash',
    component: LayoutComponent,
    children: []
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatmashRoutingModule { }
