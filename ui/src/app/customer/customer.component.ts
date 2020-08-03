import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomerService } from '../services/customer.service';
import { CustomerTypeService } from '../services/customer-type.service';
import { CustomerModel } from '../models/customer.model';

@Component({
    selector: 'app-customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.scss']
})

export class CustomerComponent implements OnInit {

  public customers: CustomerModel[] = [];
  public customerTypes: string[] = [];

  public newCustomer: CustomerModel = {
    id: 0,
    name: null,
    type: null
  };

  constructor(private customerService : CustomerService, private customerTypeService: CustomerTypeService) {
  }

  ngOnInit(): void {
    this.customerTypeService.GetCustomerTypes().subscribe(customerTypes => this.customerTypes = customerTypes);
      this.getCustomers();
  }

  public getCustomers(): void {
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
  }

  public saveCustomer(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.customerService.SaveCustomer(this.newCustomer).then(() => {
        this.getCustomers();
      });
    }
  }
}
