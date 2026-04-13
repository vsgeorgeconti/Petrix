import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
  standalone: true,
})
export class LoginComponent {
  loginForm: FormGroup;
  private returnUrl = '';
  errorMessage: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router,
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    const returnUrlParam = this.route.snapshot.queryParamMap.get('returnUrl');

    this.returnUrl = returnUrlParam && returnUrlParam.startsWith('/') ? returnUrlParam : '/';
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      const { email, password } = this.loginForm.value;

      this.authService
        .login({
          email: email,
          password: password,
        })
        .subscribe({
          next: () => {
            this.errorMessage = null;
            this.router.navigateByUrl(this.returnUrl);
          },
          error: (err) => {
            this.errorMessage = err.error?.message ?? 'Credenciais inválidas.';
          },
        });
    }
  }
}
