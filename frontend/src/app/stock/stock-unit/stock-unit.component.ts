import { Component, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';

@Component({
  selector: 'app-stock-unit',
  templateUrl: './stock-unit.component.html',
  styleUrls: ['./stock-unit.component.css']
})


export class StockUnitComponent {
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
      name: 'Stock Unit 1'
    },
    {
      id : '002',
      code: '002',
      name: 'Stock Unit 2'
    },
    {
      id : '003',
      code: '003',
      name: 'Stock Unit 3'
    },
    {
      id : '004',
      code: '004',
      name: 'Stock Unit 4'
    },
    {
      id : '005',
      code: '005',
      name: 'Stock Unit 5'
    },
    {
      id : '006',
      code: '006',
      name: 'Stock Unit 6'
    },
    {
      id : '007',
      code: '007',
      name: 'Stock Unit 7'
    },
    {
      id : '008',
      code: '008',
      name: 'Stock Unit 8'
    },
    {
      id : '009',
      code: '009',
      name: 'Stock Unit 9'
    },
    {
      id : '010',
      code: '010',
      name: 'Stock Unit 10'
    },
    {
      id : '011',
      code: '011',
      name: 'Stock Unit 11'
    },
    {
      id : '012',
      code: '012',
      name: 'Stock Unit 12'
    },
    {
      id : '013',
      code: '013',
      name: 'Stock Unit 13'
    },
    {
      id : '014',
      code: '014',
      name: 'Stock Unit 14'
    },
    {
      id : '015',
      code: '015',
      name: 'Stock Unit 15'
    },
    {
      id : '016',
      code: '016',
      name: 'Stock Unit 16'
    },
  ]
}
function notify(arg0: string) {
  throw new Error('Function not implemented.');
}

