import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
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
