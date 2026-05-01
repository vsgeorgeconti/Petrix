import { CommonModule } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { MeResponse } from '../../../features/auth/models/me-response.model';
import { AuthService } from '../../../features/auth/services/auth.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, CommonModule],
  templateUrl: './navbar.html',
})
export class NavbarComponent implements OnInit {
  user: MeResponse | null = null;

  constructor(
    private authService: AuthService,
    private router: Router,
  ) {}

  menuOpen = signal(false);

  ngOnInit(): void {
    this.authService.getCurrentUser().subscribe((Me) => {
      this.user = Me;
    });
  }

  toggleMenu() {
    this.menuOpen.update(v => !v);
  }

  getInitials(name: string): string {
    const names = name.split(' ');
    const initials = names
                    .map((n) => n.charAt(0).toUpperCase())
                    .join('')
                    .slice(0,2);
    return initials;
  }

  logout() : void {
    this.authService.logout()
    this.router.navigate(['/login']);
  }
}
