import { Component, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';


@Component({
  selector: 'app-stock-type',
  templateUrl: './stock-type.component.html',
  styleUrls: ['./stock-type.component.css']
})


export class StockTypeComponent {
  successButtonOptions: any;
  cancelButtonOptions: any;
  copyButtonOptions: any;
  readonly allowedPageSizes = [10, 20, 'all'];

  readonly displayModes = [{ text: "Display Mode 'full'", value: 'full' }, { text: "Display Mode 'compact'", value: 'compact' }];

  displayMode = 'full';

  showPageSizeSelector = true;

  showInfo = true;

  showNavButtons = true;
  @ViewChild('targetDataGrid', { static: false })
  dataGrid!: DxDataGridComponent;
  constructor() {
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

    this.copyButtonOptions = {
      text: 'Copy Data',
      stylingMode: 'outlined',
      onClick: () => {
        const rowKey = this.dataGrid.instance.option('editing.editRowKey');
        const rowIndex = this.dataGrid.instance.getRowIndexByKey(rowKey);
        const name = this.dataGrid.instance.cellValue(rowIndex, 'FirstName');
        const message = name ? name + "'s " : '';
        notify(`Copy ${message}data`);
      },
    };
  }
  dataSource= [
    {
      id : '001',
      code: '001',
      name: 'Stock Type 1',
      condition: true
    },
    {
      id : '002',
      code: '002',
      name: 'Stock Type 2',
      condition: true
    },
    {
      id : '003',
      code: '003',
      name: 'Stock Type 3',
      condition: true
    },
    {
      id : '004',
      code: '004',
      name: 'Stock Type 4',
      condition: true
    },
    {
      id : '005',
      code: '005',
      name: 'Stock Type 5',
      condition: true
    },
    {
      id : '006',
      code: '006',
      name: 'Stock Type 6',
      condition: true
    },
    {
      id : '007',
      code: '007',
      name: 'Stock Type 7',
      condition: true
    },
    {
      id : '008',
      code: '008',
      name: 'Stock Type 8',
      condition: true
    },
    {
      id : '009',
      code: '009',
      name: 'Stock Type 9',
      condition: true
    },
    {
      id : '010',
      code: '010',
      name: 'Stock Type 10',
      condition: true
    },
    {
      id : '011',
      code: '011',
      name: 'Stock Type 11',
      condition: true
    },
    {
      id : '012',
      code: '012',
      name: 'Stock Type 12',
      condition: true
    },
    {
      id : '013',
      code: '013',
      name: 'Stock Type 13',
      condition: true
    },
    {
      id : '014',
      code: '014',
      name: 'Stock Type 14',
      condition: true
    },
    {
      id : '015',
      code: '015',
      name: 'Stock Type 15',
      condition: true
    },
    {
      id : '016',
      code: '016',
      name: 'Stock Type 16',
      condition: true
    },
  ]



}


function notify(arg0: string) {
  throw new Error('Function not implemented.');
}

