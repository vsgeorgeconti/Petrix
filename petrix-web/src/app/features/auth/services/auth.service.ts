import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { ApiResponse } from '../../../core/models/api-response.model';
import { LoginRequest } from '../models/login-request.model';
import { LoginResponse } from '../models/login-response.model';
import { MeResponse } from '../models/me-response.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private urlApi = 'http://localhost:5000/api/v1/auth';

  constructor(private http: HttpClient) {}

  login(request: LoginRequest): Observable<ApiResponse<LoginResponse>> {
    return this.http
      .post<ApiResponse<LoginResponse>>(`${this.urlApi}/login`, {
        email: request.email,
        password: request.password,
      })
      .pipe(
        tap((resp) => {
          if (resp.success && resp.data?.accessToken) {
            localStorage.setItem('petrix_token', resp.data.accessToken);
          }
        }),
      );
  }

  getToken(): string | null {
    return localStorage.getItem('petrix_token');
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  getCurrentUser(): Observable<MeResponse> {
    return this.http.get<MeResponse>(`${this.urlApi}/me`);
  }

  logout(): void {
    localStorage.removeItem('petrix_token');
  }
}