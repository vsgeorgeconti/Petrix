import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth-guard';

export const routes: Routes = [
  {
    path: 'login',
    loadComponent: () => import('./features/auth/pages/login/login').then((m) => m.LoginComponent),
  },
  {
    path: '',
    canActivate: [authGuard],
    loadComponent: () =>
      import('./layouts/authenticated-layout/authenticated-layout').then(
        (m) => m.AuthenticatedLayoutComponent,
      ),
    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
      },
      {
        path: 'dashboard',
        loadComponent: () =>
          import('./features/dashboard/pages/dashboard/dashboard').then(
            (m) => m.DashboardComponent,
          ),
      },
      {
        path: 'customers',
        loadComponent: () =>
          import('./features/customer/pages/customer-list/customer-list').then(
            (m) => m.CustomerListComponent,
          ),
      },
      {
        path: 'customer/new',
        loadComponent: () =>
          import('./features/customer/pages/customer-form/customer-form').then(
            (m) => m.CustomerFormComponent,
          ),
      },
      {
        path: 'customer/:id',
        loadComponent: () =>
          import('./features/customer/pages/customer-form/customer-form').then(
            (m) => m.CustomerFormComponent,
          ),
      },
    ],
  },

  { path: '', redirectTo: 'login', pathMatch: 'full' },
];
