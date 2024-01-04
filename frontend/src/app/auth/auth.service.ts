import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private loggedInSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  get isLoggedIn$(): Observable<boolean> {
    return this.loggedInSubject.asObservable();
  }

  constructor(private http: HttpClient) {}

  async login(username: string, password: string): Promise<boolean> {
    const url = `https://localhost:44369/600106?username=${username}&password=${password}`;
    try {
      const res: any = await this.http.get(url).toPromise();
      
      this.loggedInSubject.next(true);
      return true
    } catch (error: any) {
      
      this.loggedInSubject.next(false);
      Swal.fire('Error', error.error.error.message, 'error');
      return false
    }
  }

  logout(): void {
    this.loggedInSubject.next(false);
  }

  isLoggedIn(): Observable<boolean> {
    return this.isLoggedIn$;
  }
}
