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

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    DenemeComponent,
    StockTypeComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    BreadcrumbModule,
    AppRoutingModule,
    DxDataGridModule,
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
