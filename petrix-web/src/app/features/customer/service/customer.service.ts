import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../../core/models/api-response.model';
import { CreateCustomerRequest, Customer, UpdateCustomerRequest } from '../models/customer-model';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  private apiUrl = 'https://localhost:7122/api/v1/customers';

  constructor(private http: HttpClient) {}

  
  getAllCustomers(): Observable<ApiResponse<Customer[]>>{
    return this.http.get<ApiResponse<Customer[]>>(this.apiUrl);
  }

  getCustomerById(id: string): Observable<ApiResponse<Customer>>{
    return this.http.get<ApiResponse<Customer>>(`${this.apiUrl}/${id}`);
  }

  createCustomer(customer: CreateCustomerRequest): Observable<ApiResponse<Customer>>{
    return this.http.post<ApiResponse<Customer>>(this.apiUrl, customer);
  }

  updateCustomer(id: string, customer : UpdateCustomerRequest): Observable<ApiResponse<Customer>>{
    return this.http.put<ApiResponse<Customer>>(`${this.apiUrl}/${id}`, customer);
  }

  deleteCustomer(id: string): Observable<void>{
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
