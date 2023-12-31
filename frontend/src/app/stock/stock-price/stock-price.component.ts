import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import { formatDate } from 'devextreme/localization';
import { ToastrService } from 'ngx-toastr';
import { lastValueFrom } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-stock-price',
  templateUrl: './stock-price.component.html',
  styleUrls: ['./stock-price.component.css']
})
export class StockPriceComponent {
  successButtonOptions: any;
  cancelButtonOptions: any;
  copyButtonOptions: any;
  result:any;
  requests: string[] = [];
  readonly allowedPageSizes = [10, 20, 'all'];

  readonly displayModes = [{ text: "Display Mode 'full'", value: 'full' }, { text: "Display Mode 'compact'", value: 'compact' }];

  displayMode = 'full';

  showPageSizeSelector = true;

  stockCardLookup:any;

  showInfo = true;
  dataSource:any;
  showNavButtons = true;
  @ViewChild('targetDataGrid', { static: false })
  dataGrid!: DxDataGridComponent;
  constructor(private http: HttpClient, private toastr:ToastrService) {
    this.dataSource = new CustomStore({
      key: 'id',
      load: () => this.sendRequest('https://localhost:44369/100504'),
      // insert: (values) => this.sendRequest('https://localhost:44369/100501', 'POST', values),
      // update: (key, values) => this.sendRequest(`https://localhost:44369/100502/${key}`, 'PUT', values),
      // remove: (key) => this.sendRequest(`https://localhost:44369/100502/${key}`, 'DELETE'),
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

    this.http.get('https://localhost:44369/100104').subscribe((res:any) => {
      this.stockCardLookup = res.data;
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
    }
  
    return lastValueFrom(this.result)
      .then((data: any) => {
        if (method === 'GET') {
          return data.data;
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

  onRowInserting(e: any) {
    e.cancel = true
    try {
      this.http.post('https://localhost:44369/100501', e.data).subscribe(
        (res: any) => {
          this.toastr.success('Data saved successfully', 'Success', {
            closeButton: true,
            timeOut: 5000
          });
          this.http.get('https://localhost:44369/100504').subscribe((res:any) => {
            this.dataSource = res.data
          })
          e.component.cancelEditData();
        },
        (error: any) => {
          console.error('An error occurred:', error);
          Swal.fire('Error', error.error.error.message, 'error');
          throw error;
        }
      );
    } catch (error) {
      console.error('An error occurred:', error);
    }
  }

  onRowUpdating(e:any){
    e.cancel = true
    try {
      this.http.put('https://localhost:44369/100502/' + e.key, e.newData).subscribe((res:any) => {
        this.toastr.success('Data updated successfully', 'Success', {
          closeButton: true,
          timeOut: 5000
        });
        this.http.get('https://localhost:44369/100504').subscribe((res:any) => {
            this.dataSource = res.data
          })
        e.component.cancelEditData();
      },
      (error:any) => {
        console.error('An error occured:', error);
        Swal.fire('Error', error.error.error.message, 'error');
        throw error;
      });
    } catch (error) {
      console.error('An error occurred:', error);
    }
  }

  onRowRemoving(e:any) {
    e.cancel = true
    try {
      this.http.delete('https://localhost:44369/100503/' + e.key).subscribe((res:any) => {
        debugger
        this.toastr.success('Data removed successfully', 'Success', {
          closeButton: true,
          timeOut:5000
        });
        this.http.get('https://localhost:44369/100504').subscribe((res:any) => {
            this.dataSource = res.data
          })
        e.component.cancelEditData();
      },
      (error:any) => {
        console.error('An error occured:', error);
        Swal.fire('Error', error.error.error.message, 'error');
        throw error;
      })
    } catch (error) {
      console.error('An error occured:', error);
    }
  }
}
