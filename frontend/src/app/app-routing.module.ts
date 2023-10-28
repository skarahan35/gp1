import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DenemeComponent } from './deneme/deneme.component';

const routes: Routes = [
  {
    path: 'deneme',
    component: DenemeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
