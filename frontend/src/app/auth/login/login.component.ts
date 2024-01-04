import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: any = '';
  password: any = '';
  loginForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router) {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.authService.isLoggedIn().subscribe((res:any) => {
      if(res == false){
        this.router.navigate(['/login'])
      }
    });
  }
  goToRegisterPage() {
    this.router.navigate(['/register']); // Replace '/register' with the actual route path for your registration page
  }
  async login() {
    if (this.loginForm.valid) {
      const username = this.loginForm.get('username')!.value;
      const password = this.loginForm.get('password')!.value;

      const isLoggedIn = await this.authService.login(username, password);

      if (isLoggedIn) {
        this.router.navigate(['/homepage']);
      } else {
      }
    }
  }
}
