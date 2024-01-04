import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  username: any = '';
  email:any = '';
  password: any = '';
  loginForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router,private http: HttpClient, private toastr: ToastrService) {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
  goToLoginPage() {
    this.router.navigate(['/login']); // Replace '/register' with the actual route path for your registration page
  }
  async signup() {
    if (this.loginForm.valid) {
      const username = this.loginForm.get('username')!.value;
      const email = this.loginForm.get('email')!.value;
      const password = this.loginForm.get('password')!.value;
      let data = {
        userName: username,
        eMail: email,
        password: password
      }
      this.http.post('https://localhost:44369/600101', data).subscribe((res:any) => {
        this.toastr.success('Data updated successfully', 'Success', {
          closeButton: true,
          timeOut: 5000
        });
        this.router.navigate(['/login'])
      },
      (error) => {
        Swal.fire('Error', error.error.error.message, 'error')
      })
    }
  }
}
