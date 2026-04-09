import { Component } from '@angular/core';
import { AuthService } from '../../../auth/services/auth.service';
import { Router } from '@angular/router';
import { MeResponse } from '../../../auth/models/me-response.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class DashboardComponent {
  userData: MeResponse | null = null;
  constructor(private authService: AuthService, private router: Router, ){}

  ngOnInit() : void {
    this.authService.getCurrentUser().subscribe({ next: (Me) => {
      this.userData = Me;
      console.log(this.userData);
    }})
  }

  logout() : void {
    this.authService.logout()
    this.router.navigateByUrl('/login');
  }
}
