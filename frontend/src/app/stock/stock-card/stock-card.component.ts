import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import { formatDate } from 'devextreme/localization';
import { ToastrService } from 'ngx-toastr';
import { lastValueFrom } from 'rxjs';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-stock-card',
  templateUrl: './stock-card.component.html',
  styleUrls: ['./stock-card.component.css']
})
export class StockCardComponent {
  successButtonOptions: any;
  cancelButtonOptions: any;
  copyButtonOptions: any;
  result:any;
  requests: string[] = [];
  readonly allowedPageSizes = [10, 20, 'all'];

  readonly displayModes = [{ text: "Display Mode 'full'", value: 'full' }, { text: "Display Mode 'compact'", value: 'compact' }];

  displayMode = 'full';

  showPageSizeSelector = true;

  stockTypeLookup:any;
  stockUnitLookup:any;
  stockGroupLookup:any;

  showInfo = true;
  dataSource:any;
  showNavButtons = true;
  @ViewChild('targetDataGrid', { static: false })
  dataGrid!: DxDataGridComponent;
  constructor(private http: HttpClient, private toastr:ToastrService) {
    this.dataSource = new CustomStore({
      key: 'id',
      load: () => this.sendRequest('https://localhost:44369/100104'),
      insert: (values) => this.sendRequest('https://localhost:44369/100101', 'POST', values),
      update: (key, values) => this.sendRequest(`https://localhost:44369/100102/${key}`, 'PUT', values),
      remove: (key) => this.sendRequest(`https://localhost:44369/100103/${key}`, 'DELETE'),
    });
    this.successButtonOptions = {
      type: 'success',
      stylingMode: 'outlined',
      text: 'Save',
      onClick: () => {
        this.dataGrid.instance.saveEditData();
      },
    };

    this.cancelButtonOptions = {
      type: 'danger',
      stylingMode: 'outlined',
      text: 'Cancel',
      onClick: () => {
        this.dataGrid.instance.cancelEditData();
      },
    };

    this.http.get('https://localhost:44369/100204').subscribe((res:any) => {
      this.stockTypeLookup = res.data;
    })
    this.http.get('https://localhost:44369/100304').subscribe((res:any) => {
      this.stockUnitLookup = res.data;
    })
    this.http.get('https://localhost:44369/100404').subscribe((res:any) => {
      this.stockGroupLookup = res.data;
    })
  }

  sendRequest(url: string, method = 'GET', data: any = {}): any {
    this.logRequest(method, url, data);
    const httpParams = new HttpParams({ fromObject: data });
    const httpOptions = { withCredentials: false, body: httpParams };
  
    switch (method) {
      case 'GET':
        this.result = this.http.get(url, httpOptions);
        break;
      case 'PUT':
        this.result = this.http.put(url, data, httpOptions);
        break;
      case 'POST':
        this.result = this.http.post(url, data, httpOptions);
        break;
      case 'DELETE':
        this.result = this.http.delete(url, httpOptions);
        break;
    }
  
    return lastValueFrom(this.result)
      .then((data: any) => {
        if (method === 'GET') {
          return data.data;
        } 
        else if (method === 'POST') {
          // Başarılı kayıt durumunda toastr ile uyarı mesajı göster
          this.toastr.success('Data saved successfully', 'Success', {
            closeButton: true,
            timeOut: 5000
          });
          return data;
        } 
        else if (method  === 'PUT'){
          this.toastr.success('Data updated successfully', 'Success', {
            closeButton: true,
            timeOut: 5000
          });
          return data;
        }
        else if (method === 'DELETE'){
          this.toastr.success('Data deleted successfully', 'Success', {
            closeButton: true,
            timeOut: 5000
          });
          return data;
        }
        else {
          return data;
        }
      })
      .catch((e) => {
        Swal.fire('Error', e.error.error.message, 'error')
        // e.error.error.message
        // throw e && e.error && e.error.Message;
      });
  }
  logRequest(method: string, url: string, data: any): void {
    const args = Object.keys(data || {}).map((key) => `${key}=${data[key]}`).join(' ');

    const time = formatDate(new Date(), 'HH:mm:ss');

    this.requests.unshift([time, method, url.slice(URL.length), args].join(' '));
  }

  clearRequests() {
    this.requests = [];
  }
}
