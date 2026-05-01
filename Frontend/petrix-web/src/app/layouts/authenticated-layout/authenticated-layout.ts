import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from '../../shared/components/navbar/navbar';

@Component({
  selector: 'app-authenticated-layout',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent],
  templateUrl: './authenticated-layout.html',
})
export class AuthenticatedLayoutComponent {

  
}