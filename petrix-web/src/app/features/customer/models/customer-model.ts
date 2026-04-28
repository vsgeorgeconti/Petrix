export interface Customer {
  id: string;
  name: string;
  documentNumber: string;
  email: string | null;
  phone: string | null;
  isActive: boolean;
}

export interface CreateCustomerRequest {
  name: string;
  documentNumber: string;
  email: string | null;
  phone: string | null;
}

export interface UpdateCustomerRequest {
  name: string;
  email: string | null;
  phone: string | null;
}