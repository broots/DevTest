import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CustomerDetailComponent } from './customer-detail.component';

let component: CustomerDetailComponent;
let fixture: ComponentFixture<CustomerDetailComponent>;

describe('customer-detail component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CustomerDetailComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CustomerDetailComponent);
        component = fixture.componentInstance;
    }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
