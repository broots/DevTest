import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Globals } from '../globals';

@Injectable({
  providedIn: 'root'
})

@Injectable()
export class CustomerTypeService {
  private baseUrl: string;
  constructor(private httpClient: HttpClient, private globals: Globals) {
    this.baseUrl = globals.apiBaseUrl + '/customertype';
  }

  public GetCustomerTypes(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.baseUrl);
  }
}
