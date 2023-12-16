import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';
import { ToastrModule, provideToastr } from 'ngx-toastr';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { DenemeComponent } from './deneme/deneme.component';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { DxDataGridModule } from 'devextreme-angular';
import { StockTypeComponent } from './stock/stock-type/stock-type.component';
import { StockUnitComponent } from './stock/stock-unit/stock-unit.component';
import { StockGroupComponent } from './stock/stock-group/stock-group.component';
import {
  HttpClient, HttpClientModule, HttpHeaders, HttpParams,
} from '@angular/common/http';
import Swal from 'sweetalert2';
import { StockCardComponent } from './stock/stock-card/stock-card.component';
import { StockPriceComponent } from './stock/stock-price/stock-price.component';
import { CustomerTypeComponent } from './customer/customer-type/customer-type.component';
import { CustomerGroupComponent } from './customer/customer-group/customer-group.component';
import { CountriesComponent } from './locations/countries/countries.component';
import { CitiesComponent } from './locations/cities/cities.component';
import { DistrictsComponent } from './locations/districts/districts.component';
import { CustomerCardComponent } from './customer/customer-card/customer-card.component';
import { CustomerAddressComponent } from './customer/customer-address/customer-address.component';
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    DenemeComponent,
    StockTypeComponent,
    StockUnitComponent,
    StockGroupComponent,
    StockCardComponent,
    StockPriceComponent,
    CustomerTypeComponent,
    CustomerGroupComponent,
    CountriesComponent,
    CitiesComponent,
    DistrictsComponent,
    CustomerCardComponent,
    CustomerAddressComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    BreadcrumbModule,
    AppRoutingModule,
    DxDataGridModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [
    provideAnimations(), 
    provideToastr(),
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
