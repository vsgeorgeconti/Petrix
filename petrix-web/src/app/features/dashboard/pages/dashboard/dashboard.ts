import { Component, inject } from '@angular/core';
import { AuthService } from '../../../auth/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class DashboardComponent {
  constructor(private authService: AuthService, private router: Router){}
  logout() : void {
    this.authService.logout()
    this.router.navigateByUrl('/login');
  }
}

