import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DenemeComponent } from './deneme/deneme.component';
import { StockTypeComponent } from './stock/stock-type/stock-type.component';
import { StockUnitComponent } from './stock/stock-unit/stock-unit.component';
import { StockGroupComponent } from './stock/stock-group/stock-group.component';
import { StockCardComponent } from './stock/stock-card/stock-card.component';
import { StockPriceComponent } from './stock/stock-price/stock-price.component';
import { CustomerTypeComponent } from './customer/customer-type/customer-type.component';
import { CustomerGroupComponent } from './customer/customer-group/customer-group.component';
import { CountriesComponent } from './locations/countries/countries.component';
import { CitiesComponent } from './locations/cities/cities.component';
import { DistrictsComponent } from './locations/districts/districts.component';
import { CustomerCardComponent } from './customer/customer-card/customer-card.component';
import { CustomerAddressComponent } from './customer/customer-address/customer-address.component';
import { CompanyComponent } from './companies/company/company.component';

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
  },
  {
    path: 'stock/stock-card',
    component: StockCardComponent
  },
  {
    path: 'stock/stock-price',
    component: StockPriceComponent
  },
  {
    path: 'customer/customer-type',
    component: CustomerTypeComponent
  },
  {
    path: 'customer/customer-group',
    component: CustomerGroupComponent
  },
  {
    path: 'location/countries',
    component: CountriesComponent
  },{
    path: 'location/cities',
    component: CitiesComponent
  },
  {
    path: 'location/districts',
    component: DistrictsComponent
  },
  {
    path: 'customer/customer-card',
    component: CustomerCardComponent
  },
  {
    path: 'customer/customer-address',
    component: CustomerAddressComponent
  },
  {
    path: 'companies/company',
    component: CompanyComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
