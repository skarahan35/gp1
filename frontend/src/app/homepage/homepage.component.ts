import { Component } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {
  constructor(private authService: AuthService, private router:Router){
    this.authService.isLoggedIn().subscribe((res:any) => {
      if(res == false){
        this.router.navigate(['/login'])
      }
    });
  }
}
