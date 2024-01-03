import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, ViewChild, ViewContainerRef } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import { formatDate } from 'devextreme/localization';
import { ToastrService } from 'ngx-toastr';
import { lastValueFrom } from 'rxjs';
import Swal from 'sweetalert2';
import * as Excel from "exceljs";
import { saveAs } from 'file-saver-es';
import { exportDataGrid } from 'devextreme/excel_exporter';

@Component({
  selector: 'app-customer-address',
  templateUrl: './customer-address.component.html',
  styleUrls: ['./customer-address.component.css']
})
export class CustomerAddressComponent {
  customerCardId:any;
  masterData:any;
  visible = true;
  keyCount= 0;
  dataSourceDetail:any;
  DetailData:any[] = [];
  @ViewChild('targetDataGrid2', { static: false }) dataGrid2!: DxDataGridComponent;
  @ViewChild('gridContainer', { read: ViewContainerRef }) gridContainer!: ViewContainerRef;
  successButtonOptions: any;
  cancelButtonOptions: any;
  copyButtonOptions: any;
  result:any;
  requests: string[] = [];
  readonly allowedPageSizes = [10, 20, 'all'];

  readonly displayModes = [{ text: "Display Mode 'full'", value: 'full' }, { text: "Display Mode 'compact'", value: 'compact' }];

  displayMode = 'full';

  showPageSizeSelector = true;

  customerCardLookup:any;
  districtLookup:any;
  cityLookup:any;
  countryLookup:any;

  showInfo = true;
  dataSource:any;
  showNavButtons = true;
  @ViewChild('targetDataGrid', { static: false })
  dataGrid!: DxDataGridComponent;
  constructor(private http: HttpClient, private toastr:ToastrService) {
    this.http.get('https://localhost:44369/200304').subscribe((res:any) => {
      this.dataSource = res.data
    })
    this.dataSourceDetail = []
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

    this.http.get('https://localhost:44369/200304').subscribe((res:any) => {
      this.customerCardLookup = res.data;
    })
    this.http.get('https://localhost:44369/700304').subscribe((res:any) => {
      this.districtLookup = res.data;
    })

    this.http.get('https://localhost:44369/700204').subscribe((res:any) => {
      this.cityLookup = res.data;
    })
    this.http.get('https://localhost:44369/700104').subscribe((res:any) => {
      this.countryLookup = res.data;
    })
  }

  onShowingPopup = (e:any) => {
    this.visible = true
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

  onEditingStartMaster = (e:any) =>{
    this.customerCardId = e.key,
    this.masterData = e.data
    this.visible = true
    this.http.get('https://localhost:44369/200206/' + e.key ).subscribe((res:any) => {
      this.dataSourceDetail = res
      // this.dataGrid2.instance.refresh()
    })
  }

  onHiddenHeaderPopup = (e: any) => {
    this.visible = false
    this.dataSourceDetail = []
    this.gridContainer.clear()
    // this.dataGrid2.instance.refresh()
    this.DetailData = [];
  };

  onRowInserting(e: any) {
    e.data.keyCount = this.keyCount
    const newData = e.data
    let data = {
      data: newData,
      type: 'insert',
      key: ''
    }

    this.DetailData.push(data)
    
    this.keyCount +=1
  }

  onRowUpdating(e:any){
    let flag = false
    for (var key in e.newData) {
      if (e.oldData.hasOwnProperty(key)) {
        e.oldData[key] = e.newData[key];
      }
    }
    this.DetailData.forEach((item:any) => {
      if((item.data.keyCount || item.data.keyCount == 0) && (item.data.keyCount == e.oldData.keyCount)){
        flag = true
        for(const key in e.newData){
          item.data[key] = e.newData[key]
        }
      }
      
    })
    if(flag == false) {
      let data = {
        data : e.oldData,
        key: e.key,
        type: 'update'
      }

      this.DetailData.push(data)
    }
  }

  onRowRemoving(e:any) {
    if(!e.data.hasOwnProperty('keyCount')){
      let data = {
        data: e.data,
        key: e.data.id,
        type: 'remove'
      }
      this.DetailData.push(data)
    }
    else {
      for (let i = 0; i < this.DetailData.length; i++) {
        if (this.DetailData[i].data.keyCount !== undefined && this.DetailData[i].data.keyCount === e.data.keyCount) {
          // Silinen veriyi bulduk, şimdi diziden kaldıralım
          this.DetailData.splice(i, 1);
          break; // Döngüden çık, işimiz tamam
        }
      }
    }
  }
  onSavingHeader(e:any) {
        e.cancel = true
        
        this.DetailData.forEach((item:any) => {
          if(item.type == 'insert'){
            let data = this.customerCardId
            item.data.customerCardId = data
          this.http.post('https://localhost:44369/200201', item.data).subscribe((res:any) => {
            e.component.cancelEditData();
            this.http.get('https://localhost:44369/200304').subscribe((res:any) => {
              this.dataSource = res.data
            })
            this.toastr.success('Data saved successfully', 'Success', {
              closeButton: true,
              timeOut: 5000
            });
          })
          }
          if(item.type == 'update'){
            this.http.put('https://localhost:44369/200202/'+ item.data.id, item.data).subscribe((res:any) => {
              e.component.cancelEditData();
              this.http.get('https://localhost:44369/200304').subscribe((res:any) => {
                this.dataSource = res.data
              })
              this.toastr.success('Data updated successfully', 'Success', {
                closeButton: true,
                timeOut: 5000
              });
            })
          }
          if(item.type == 'remove'){
            this.http.delete('https://localhost:44369/200203/' + item.data.id).subscribe((res:any) => {
              e.component.cancelEditData();
              this.http.get('https://localhost:44369/200304').subscribe((res:any) => {
                this.dataSource = res.data
              })
              this.toastr.success('Data removed successfully', 'Success', {
                closeButton: true,
                timeOut: 5000
              });
            })
          }
        })
  }
}
