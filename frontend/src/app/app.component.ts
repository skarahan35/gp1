import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from './auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'gp1';
  isLoggedIn: boolean = false;
  constructor(private toastr: ToastrService, private authService: AuthService){

      this.authService.isLoggedIn().subscribe((res:any) => {
        this.isLoggedIn = res
      });
  }
  
}
