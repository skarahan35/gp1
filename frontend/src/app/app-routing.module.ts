import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DenemeComponent } from './deneme/deneme.component';
import { StockTypeComponent } from './stock/stock-type/stock-type.component';

const routes: Routes = [
  {
    path: 'deneme',
    component: DenemeComponent
  },
  {
    path: 'stock/stock-type',
    component: StockTypeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
