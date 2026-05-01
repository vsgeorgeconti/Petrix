import { Component } from '@angular/core';
import { AuthService } from '../../../auth/services/auth.service';
import { MeResponse } from '../../../auth/models/me-response.model';
import { CommonModule } from '@angular/common';
import { Spinner } from "../../../../shared/components/spinner/spinner";

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, Spinner],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class DashboardComponent {
  userData: MeResponse | null = null;
  errorMessage: string | null = null;
  isLoading = true;
  hasError = false;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.authService.getCurrentUser().subscribe({
      next: (me) => {
        this.userData = me;
        this.isLoading = false;
        this.hasError = false;
      },
      error: (err) => {
        this.isLoading = false;
        this.hasError = true;
        this.errorMessage = err.error?.message ?? 'Erro ao carregar os dados. Tente novamente.';
      },
    });
  }
  
}
