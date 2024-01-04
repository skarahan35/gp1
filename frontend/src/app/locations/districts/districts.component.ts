import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import { formatDate } from 'devextreme/localization';
import { ToastrService } from 'ngx-toastr';
import { lastValueFrom } from 'rxjs';
import Swal from 'sweetalert2';
import * as Excel from "exceljs";
import { saveAs } from 'file-saver-es';
import { exportDataGrid } from 'devextreme/excel_exporter';
import { AuthService } from 'src/app/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-districts',
  templateUrl: './districts.component.html',
  styleUrls: ['./districts.component.css']
})
export class DistrictsComponent {
  successButtonOptions: any;
  cancelButtonOptions: any;
  copyButtonOptions: any;
  result:any;
  requests: string[] = [];
  readonly allowedPageSizes = [10, 20, 'all'];

  readonly displayModes = [{ text: "Display Mode 'full'", value: 'full' }, { text: "Display Mode 'compact'", value: 'compact' }];

  displayMode = 'full';

  showPageSizeSelector = true;

  showInfo = true;
  dataSource:any;
  showNavButtons = true;
  @ViewChild('targetDataGrid', { static: false })
  dataGrid!: DxDataGridComponent;
  constructor(private http: HttpClient, private toastr:ToastrService, private authService: AuthService, private router: Router) {
    this.authService.isLoggedIn().subscribe((res:any) => {
      if(res == false){
        this.router.navigate(['/login'])
      }
    });
    this.dataSource = new CustomStore({
      key: 'id',
      load: () => this.sendRequest('https://localhost:44369/700304'),
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
      this.http.post('https://localhost:44369/700301', e.data).subscribe(
        (res: any) => {
          this.toastr.success('Data saved successfully', 'Success', {
            closeButton: true,
            timeOut: 5000
          });
          this.http.get('https://localhost:44369/700304').subscribe((res:any) => {
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
      this.http.put('https://localhost:44369/700302/' + e.key, e.newData).subscribe((res:any) => {
        this.toastr.success('Data updated successfully', 'Success', {
          closeButton: true,
          timeOut: 5000
        });
        this.http.get('https://localhost:44369/700304').subscribe((res:any) => {
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
      this.http.delete('https://localhost:44369/700303/' + e.key).subscribe((res:any) => {
        this.toastr.success('Data removed successfully', 'Success', {
          closeButton: true,
          timeOut:5000
        });
        this.http.get('https://localhost:44369/700304').subscribe((res:any) => {
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
  onExporting(e: any) {
    const workbook = new Excel.Workbook();
    const worksheet = workbook.addWorksheet('Download');

    exportDataGrid({
      component: e.component,
      worksheet,
      autoFilterEnabled: true,
    }).then(() => {
      workbook.xlsx.writeBuffer().then((buffer) => {
        saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'Download.xlsx');
      });
    });
    e.cancel = true;
}
}
