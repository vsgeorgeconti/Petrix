import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
  standalone: true,
})
export class LoginComponent {
  loginForm: FormGroup;
  private returnUrl = '';

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

    this.returnUrl =
      returnUrlParam && returnUrlParam.startsWith('/') ? returnUrlParam : '/dashboard';
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
            this.router.navigateByUrl(this.returnUrl);
          },
          error: (err) => console.error('Erro: ', err),
        });
    }
  }
}
