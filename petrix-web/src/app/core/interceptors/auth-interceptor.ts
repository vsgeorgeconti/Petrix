import { HttpInterceptorFn } from '@angular/common/http';
import { AuthService } from '../../features/auth/services/auth.service';
import { inject } from '@angular/core';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const token = authService.getToken();

  if (req.url.includes('/auth/login') || req.url.includes('/auth/register')) 
    return next(req);
  
  if(!token)
    return next(req);

  const clonedRequest = req.clone({
    headers: req.headers.set('Authorization', `Bearer ${token}`)
  });
  return next(clonedRequest);
};
