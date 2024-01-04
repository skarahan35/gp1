import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DenemeComponent } from './deneme/deneme.component';
import { StockTypeComponent } from './stock/stock-type/stock-type.component';
import { StockUnitComponent } from './stock/stock-unit/stock-unit.component';
import { StockGroupComponent } from './stock/stock-group/stock-group.component';
import { StockCardComponent } from './stock/stock-card/stock-card.component';
import { CustomerTypeComponent } from './customer/customer-type/customer-type.component';
import { CustomerGroupComponent } from './customer/customer-group/customer-group.component';
import { CountriesComponent } from './locations/countries/countries.component';
import { CitiesComponent } from './locations/cities/cities.component';
import { DistrictsComponent } from './locations/districts/districts.component';
import { CustomerCardComponent } from './customer/customer-card/customer-card.component';
import { CustomerAddressComponent } from './customer/customer-address/customer-address.component';
import { CompanyComponent } from './companies/company/company.component';
import { MovementComponent } from './movements/movement/movement.component';
import { LoginComponent } from './auth/login/login.component';
import { AuthGuard } from './auth/auth.guard';
import { HomepageComponent } from './homepage/homepage.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {
    path: 'deneme',
    component: DenemeComponent
  },
  {
    path: 'stock/stock-type',
    component: StockTypeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'stock/stock-unit',
    component: StockUnitComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'stock/stock-group',
    component: StockGroupComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'stock/stock-card',
    component: StockCardComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'customer/customer-type',
    component: CustomerTypeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'customer/customer-group',
    component: CustomerGroupComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'location/countries',
    component: CountriesComponent,
    canActivate: [AuthGuard]
  },{
    path: 'location/cities',
    component: CitiesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'location/districts',
    component: DistrictsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'customer/customer-card',
    component: CustomerCardComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'customer/customer-address',
    component: CustomerAddressComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'companies/company',
    component: CompanyComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'movements/movement',
    component: MovementComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'auth/register',
    component: RegisterComponent
  },
  {
    path: 'homepage',
    component: HomepageComponent,
    canActivate: [AuthGuard]
  },
  { path: '', redirectTo: '', pathMatch: 'full'  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
