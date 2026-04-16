import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, combineLatest, Observable } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { Spinner } from '../../../../shared/components/spinner/spinner';
import { Customer } from '../../models/customer-model';
import { CustomerService } from '../../service/customer.service';


interface PageState {
  loading: boolean;
  error: string | null;
  customers: Customer[];
}

@Component({
  standalone: true,
  selector: 'app-customer-list',
  imports: [CommonModule, Spinner],
  templateUrl: './customer-list.html',
  styleUrl: './customer-list.css',
})
export class CustomerListComponent implements OnInit {
  private refresh$ = new BehaviorSubject<void>(undefined);
  private searchTerm$ = new BehaviorSubject<string>('');

  state$!: Observable<PageState>;

  constructor(private customerService: CustomerService) {}

   ngOnInit(): void {
    const allCustomers$ = this.refresh$.pipe(
      switchMap(() =>
        this.customerService.getAllCustomers().pipe(
          map(data => data.data || []),
          catchError(() => [[]]) 
        )
      )
    );
    
    console.log('allCustomers$:', allCustomers$);
    this.state$ = combineLatest([allCustomers$, this.searchTerm$]).pipe(
      map(([customers, term]) => ({
        loading: false,
        error: null,
        customers: term
          ? customers.filter(
              c =>
                c.name.toLowerCase().includes(term) ||
                (c.email && c.email.toLowerCase().includes(term)) ||
                (c.phone && c.phone.toLowerCase().includes(term))
            )
          : customers,
      })),
      catchError(() => [{ loading: false, error: 'Erro ao carregar clientes.', customers: [] }]),
      startWith({ loading: true, error: null, customers: [] }) 
    );
  }

  onSearchChange(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.searchTerm$.next(value);
  }



  editCustomer(id: string): void {
    // Implementar lógica de edição, como navegar para uma página de edição ou abrir um modal
    console.log('Edit customer with ID:', id);
  }

  onDeleteCustomer(id: string): void {
    if (confirm('Tem certeza que deseja excluir este cliente?')) {
      this.customerService.deleteCustomer(id).subscribe({
        next: () => {
          this.refresh$.next(); 
          alert('Cliente excluído com sucesso!');
        },
        error: (error) => {
          console.error('Error deleting customer:', error);
          alert('Ocorreu um erro ao excluir o cliente. Por favor, tente novamente mais tarde.');
        },
      });
    }
  }
}
