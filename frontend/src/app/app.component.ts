import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'gp1';
  constructor(private toastr: ToastrService){
      // this.toastr.success('Toastr Deneme', 'Toastr Deneme', {
      //   timeOut: 5000,
      //   positionClass: 'toast-bottom-right',
      //   closeButton: true,
      //   progressBar: true,
      //   progressAnimation: 'decreasing',
  
      // });
  }
}
