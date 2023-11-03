import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DenemeComponent } from './deneme/deneme.component';
import { StockTypeComponent } from './stock/stock-type/stock-type.component';
import { StockUnitComponent } from './stock/stock-unit/stock-unit.component';
import { StockGroupComponent } from './stock/stock-group/stock-group.component';

const routes: Routes = [
  {
    path: 'deneme',
    component: DenemeComponent
  },
  {
    path: 'stock/stock-type',
    component: StockTypeComponent
  },
  {
    path: 'stock/stock-unit',
    component: StockUnitComponent
  },
  {
    path: 'stock/stock-group',
    component: StockGroupComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
