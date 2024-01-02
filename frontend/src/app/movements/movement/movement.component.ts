import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, ChangeDetectorRef, Component, ViewChild, ViewContainerRef } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import { formatDate } from 'devextreme/localization';
import { ToastrService } from 'ngx-toastr';
import { lastValueFrom } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-movement',
  templateUrl: './movement.component.html',
  styleUrls: ['./movement.component.css']
})
export class MovementComponent implements AfterViewInit {

  customerCardID:any;
  receiptNo:any;
  typeCode:any;
  headerId:any;
  firstAmount:any;
  discountAmount:any; 
  vatAmount:any; 
  totalAmount:any; 
  paymentType:any;

  customerCardLookup:any;
  paymentTypeLookup:any;
  customerAddressLookup:any;
  typeLookup:any;
  stockCardLookup:any;
  keyCount:number = 0
  DetailData:any[] = [];
  masterData:any;
  successButtonOptions: any;
  cancelButtonOptions: any;
  copyButtonOptions: any;
  result:any;
  visible:any = true
  requests: string[] = [];
  readonly allowedPageSizes = [10, 20, 'all'];

  readonly displayModes = [{ text: "Display Mode 'full'", value: 'full' }, { text: "Display Mode 'compact'", value: 'compact' }];

  displayMode = 'full';

  showPageSizeSelector = true;
  showInfo = true;
  dataSource:any;
  dataSourceDetail:any;
  showNavButtons = true;
  @ViewChild('targetDataGrid', { static: false })
  dataGrid!: DxDataGridComponent;
  @ViewChild('targetDataGrid2', { static: false }) dataGrid2!: DxDataGridComponent;
  @ViewChild('gridContainer', { read: ViewContainerRef }) gridContainer!: ViewContainerRef;
  @ViewChild('addressLookup') addressLookup: any;
  constructor(private http: HttpClient, private toastr:ToastrService, private cdr: ChangeDetectorRef) {
    this.dataSourceDetail = []
    // this.dataSourceDetail = new CustomStore({
    //   key: 'id',
    //   load: () => this.sendRequest('https://localhost:44369/300204'),
    // });

    this.http.get('https://localhost:44369/300104').subscribe((res:any) => {
      this.dataSource = res.data
    })

    // this.dataSource = new CustomStore({
    //   key: 'id',
    //   load: () => this.sendRequest('https://localhost:44369/300104'),
    // });
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
    this.customerAddressLookup = [];
    this.http.get('https://localhost:44369/200304').subscribe((res:any) => {
      this.customerCardLookup = res.data;
    })
    this.http.get('https://localhost:44369/300107').subscribe((res:any) => {
      this.paymentTypeLookup = res
    })
    this.http.get('https://localhost:44369/300109').subscribe((res:any) => {
      this.typeLookup = res
    })
    this.http.get('https://localhost:44369/100104').subscribe((res:any) => {
      this.stockCardLookup = res.data;
    })
  }

  setCellValueQuantity(newData:any, value:any, currentRowData:any) {
    newData.quantity = value
    if(currentRowData.price && !currentRowData.discountRate && !currentRowData.vatRate){
      newData.firstAmount = value * currentRowData.price
      newData.totalAmount = value * currentRowData.price
    }
    else if (currentRowData.price && currentRowData.discountRate && !currentRowData.vatRate){
      newData.firstAmount = value * currentRowData.price
      newData.discountAmount = (value * currentRowData.price) * (currentRowData.discountRate / 100)
      newData.totalAmount = (value * currentRowData.price) - newData.discountAmount
    }
    else if (currentRowData.price && currentRowData.discountRate && currentRowData.vatRate){
      newData.firstAmount = value * currentRowData.price
      newData.discountAmount = (value * currentRowData.price) * (currentRowData.discountRate / 100)
      newData.vatAmount = ((value * currentRowData.price) - newData.discountAmount) * (currentRowData.vatRate / 100)
      newData.totalAmount = ((value * currentRowData.price) - newData.discountAmount) + newData.vatAmount
    }
    else if (currentRowData.price && !currentRowData.discountRate && currentRowData.vatRate){
      newData.firstAmount = value * currentRowData.price
      newData.vatAmount = (value * currentRowData.price) * (currentRowData.vatRate / 100)
      newData.totalAmount = (value * currentRowData.price) + newData.vatAmount
    }
}
setCellValuePrice(newData:any, value:any, currentRowData:any) {
  newData.price = value
  if(currentRowData.quantity && !currentRowData.discountRate && !currentRowData.vatRate){
    newData.firstAmount = value * currentRowData.quantity
    newData.totalAmount = value * currentRowData.quantity
  }
  else if (currentRowData.quantity && currentRowData.discountRate && !currentRowData.vatRate){
    newData.firstAmount = value * currentRowData.quantity
    newData.discountAmount = (value * currentRowData.quantity) * (currentRowData.discountRate / 100)
    newData.totalAmount = (value * currentRowData.quantity) - newData.discountAmount
  }
  else if (currentRowData.quantity && currentRowData.discountRate && currentRowData.vatRate){
    newData.firstAmount = value * currentRowData.quantity
    newData.discountAmount = (value * currentRowData.quantity) * (currentRowData.discountRate / 100)
    newData.vatAmount = ((value * currentRowData.quantity) - newData.discountAmount) * (currentRowData.vatRate / 100)
    newData.totalAmount = ((value * currentRowData.quantity) - newData.discountAmount) + newData.vatAmount
  }
  else if (currentRowData.quantity && !currentRowData.discountRate && currentRowData.vatRate){
    newData.firstAmount = value * currentRowData.quantity
    newData.vatAmount = (value * currentRowData.quantity) * (currentRowData.vatRate / 100)
    newData.totalAmount = (value * currentRowData.quantity) + newData.vatAmount
  }

}
setCellValueDiscountRate(newData:any, value:any, currentRowData:any) {
 if(currentRowData.firstAmount){
  newData.discountRate = value
  newData.discountAmount = (value / 100) * currentRowData.firstAmount
  newData.totalAmount = currentRowData.firstAmount - newData.discountAmount
 }
 if(currentRowData.vatAmount){
  newData.vatAmount = (currentRowData.vatRate / 100) * (currentRowData.firstAmount - newData.discountAmount)
 }
}
setCellValueVATRate(newData:any, value:any, currentRowData:any) {
  if(currentRowData.firstAmount && currentRowData.discountAmount){
   newData.vatRate = value
   newData.vatAmount = (value / 100) * (currentRowData.firstAmount - currentRowData.discountAmount)
   newData.totalAmount = currentRowData.firstAmount - currentRowData.discountAmount + newData.vatAmount
  }
 }
  sendRequest(url: string, method = 'GET', data: any = {}): any {
    try {
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
          Swal.fire('Error', e.error.error.message, 'error');
          // e.error.error.message
          // throw e && e.error && e.error.Message;
        });
    } catch (error) {
      console.error('An error occurred:', error);
    }
  }
  
  logRequest(method: string, url: string, data: any): void {
    const args = Object.keys(data || {}).map((key) => `${key}=${data[key]}`).join(' ');

    const time = formatDate(new Date(), 'HH:mm:ss');

    this.requests.unshift([time, method, url.slice(URL.length), args].join(' '));
  }

  clearRequests() {
    this.requests = [];
  }

  onRowInsertingDetail(e:any){
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

  onRowUpdatingDetail(e:any){
    if(e.newData.firstAmount > e.oldData.firstAmount){
      this.firstAmount += e.newData.firstAmount - e.oldData.firstAmount
    }
    if(e.newData.discountAmount > e.oldData.discountAmount){
      this.discountAmount += e.newData.discountAmount - e.oldData.discountAmount
    }
    if(e.newData.vatAmount > e.oldData.vatAmount){
      this.vatAmount += e.newData.vatAmount - e.oldData.vatAmount
    }
    if(e.newData.totalAmount > e.oldData.totalAmount){
      this.totalAmount += e.newData.totalAmount - e.oldData.totalAmount
    }
    if(e.newData.firstAmount < e.oldData.firstAmount){
      this.firstAmount += e.newData.firstAmount - e.oldData.firstAmount
    }
    if(e.newData.discountAmount < e.oldData.discountAmount){
      this.discountAmount += e.newData.discountAmount - e.oldData.discountAmount 
    }
    if(e.newData.vatAmount < e.oldData.vatAmount){
      this.vatAmount += e.newData.vatAmount - e.oldData.vatAmount
    }
    if(e.newData.totalAmount < e.oldData.totalAmount){
      this.totalAmount += e.newData.totalAmount - e.oldData.totalAmount
    }



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
            debugger
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

  onShowingPopup = (e:any) => {
    this.visible = true
  } 

  onEditingStartMaster = (e:any) =>{
    this.customerCardID = e.data.customerCardID,
    this.receiptNo = e.data.receiptNo,
    this.typeCode = e.data.typeCode,
    this.headerId = e.data.id,
    this.firstAmount = e.data.firstAmount,
    this.discountAmount = e.data.discountAmount,
    this.vatAmount = e.data.vatAmount,
    this.totalAmount = e.data.totalAmount,
    this.paymentType = e.data.paymentType
    this.masterData = e.data
    this.visible = true
    this.http.get('https://localhost:44369/300208/' + e.key ).subscribe((res:any) => {
      this.dataSourceDetail = res
      // this.dataGrid2.instance.refresh()
    })
  }

  ngAfterViewInit() {
    this.cdr.detectChanges(); // Change detection'ı tetikle
    console.log(this.dataGrid2); // Bu satırı ekleyerek consolda görebilirsiniz
  }

  onHiddenHeaderPopup = (e: any) => {
    this.visible = false
    this.dataSourceDetail = []
    this.gridContainer.clear()
    // this.dataGrid2.instance.refresh()
    this.DetailData = [];
  };

  onRowRemovingDetail(e:any){
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

    if(e.changes[0]){
      if(e.changes[0].type == 'insert'){
        e.cancel = true
        let data = e.changes[0].data
        let firstAmount:number = 0
        let discountAmount:number = 0
        let vatAmount:number = 0
        let totalAmount:number = 0
        if(this.DetailData.length > 0){
          this.DetailData.forEach((item) => {
            firstAmount += item.data.firstAmount
            discountAmount += item.data.discountAmount
            vatAmount += item.data.vatAmount
            totalAmount += item.data.totalAmount
          })
        }
        data.firstAmount = firstAmount
        data.discountAmount = discountAmount
        data.vatAmount = vatAmount
        data.totalAmount = totalAmount
        let sendData = {
          header: data,
          details: this.DetailData
        }
        this.http.post('https://localhost:44369/300106', sendData).subscribe((res:any) => {
          e.component.cancelEditData();
          this.http.get('https://localhost:44369/300104').subscribe((res:any) => {
            this.dataSource = res.data
          })
          this.toastr.success('Data saved successfully', 'Success', {
            closeButton: true,
            timeOut: 5000
          });
        })
      }
      if(e.changes[0].type == 'update'){
        let data= {
          id: this.headerId,
          customerCardID: e.changes[0].data.customerCardID ? e.changes[0].data.customerCardID : this.customerCardID,
          receiptNo: e.changes[0].data.receiptNo ? e.changes[0].data.receiptNo : this.receiptNo,
          typeCode: e.changes[0].data.typeCode ? e.changes[0].data.typeCode : this.typeCode,
          paymentType: e.changes[0].data.paymentType ? e.changes[0].data.paymetType : this.paymentType,
          firstAmount: this.firstAmount,
          discountAmount: this.discountAmount,
          vatAmount: this.vatAmount,
          totalAmount: this.totalAmount
        }
        let sendData = {
          header: data,
          details: this.DetailData
        }
        this.http.post('https://localhost:44369/300106', sendData).subscribe((res:any) => {
          e.component.cancelEditData();
          this.http.get('https://localhost:44369/300104').subscribe((res:any) => {
            this.dataSource = res.data
          })
          this.toastr.success('Data saved successfully', 'Success', {
            closeButton: true,
            timeOut: 5000
          });
        })
      }
      if(e.changes[0].type == 'remove'){
        this.http.delete('https://localhost:44369/300103/' + e.changes[0].key).subscribe((res:any) => {
          this.http.get('https://localhost:44369/300104').subscribe((res:any) => {
            this.dataSource = res.data
          })
          this.toastr.success('Data removed successfully', 'Success', {
            closeButton: true,
            timeOut: 5000
          });
        })
      }
    }
    else {
      e.cancel = true
      let data= {
        id: this.headerId,
        customerCardID: this.customerCardID,
        receiptNo: this.receiptNo,
        typeCode: this.typeCode,
        firstAmount: this.firstAmount,
        discountAmount: this.discountAmount,
        vatAmount: this.vatAmount,
        totalAmount: this.totalAmount,
        paymentType: this.paymentType
      }
      let sendData = {
        header: data,
        details: this.DetailData
      }
      this.http.post('https://localhost:44369/300106', sendData).subscribe((res:any) => {
          e.component.cancelEditData();
          this.http.get('https://localhost:44369/300104').subscribe((res:any) => {
            this.dataSource = res.data
          })
          this.toastr.success('Data updated successfully', 'Success', {
            closeButton: true,
            timeOut: 5000
          });
        })
    }

    // if(e.changes.length < 1 && this.DetailData.length > 0){
    //   e.cancel = true
    //   let data  = this.masterData
    //   let sendData = {
    //     header: data,
    //     details: this.DetailData
    //   }
    //   this.http.post('https://localhost:44369/300106', sendData).subscribe((res:any) => {
    //     e.component.cancelEditData();
    //     this.http.get('https://localhost:44369/300104').subscribe((res:any) => {
    //       this.dataSource = res.data
    //     })
    //     this.toastr.success('Data updated successfully', 'Success', {
    //       closeButton: true,
    //       timeOut: 5000
    //     });
    //   })
    // }
  }

  onRowInserting(e: any) {
    e.cancel = true
    try {
      this.http.post('https://localhost:44369/300101', e.data).subscribe(
        (res: any) => {
          this.toastr.success('Data saved successfully', 'Success', {
            closeButton: true,
            timeOut: 5000
          });
          this.http.get('https://localhost:44369/300104').subscribe((res:any) => {
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
      this.http.put('https://localhost:44369/300102/' + e.key, e.newData).subscribe((res:any) => {
        this.toastr.success('Data updated successfully', 'Success', {
          closeButton: true,
          timeOut: 5000
        });
        this.http.get('https://localhost:44369/300104').subscribe((res:any) => {
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
      this.http.delete('https://localhost:44369/300103/' + e.key).subscribe((res:any) => {
        this.toastr.success('Data removed successfully', 'Success', {
          closeButton: true,
          timeOut:5000
        });
        this.http.get('https://localhost:44369/300104').subscribe((res:any) => {
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
