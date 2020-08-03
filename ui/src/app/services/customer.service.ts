import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerModel } from '../models/customer.model';
import { Globals } from '../globals';

@Injectable({
  providedIn: 'root'
})

@Injectable()
export class CustomerService {
  private baseUrl: string;
  constructor(private httpClient: HttpClient, private globals: Globals) {
    this.baseUrl = globals.apiBaseUrl + '/customer';
  }

  public GetCustomers(): Observable<CustomerModel[]> {
    return this.httpClient.get<CustomerModel[]>(this.baseUrl);
  }

  public GetCustomer(customerId: number): Observable<CustomerModel> {
    return this.httpClient.get<CustomerModel>(this.baseUrl + `/${customerId}`);
  }

  public SaveCustomer(customer: CustomerModel): Promise<object> {
    console.log(customer);
    return this.httpClient.post(this.baseUrl, customer).toPromise();
  }
}
