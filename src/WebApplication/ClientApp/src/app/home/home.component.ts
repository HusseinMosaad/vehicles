import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public vehicles: VehicleDetails[];
  public customers: CustomerDetails[];
  selectedCustomer_Id: string = null;
  selectedStatus: string = null;
  myAppUrl: string = "";
  _http: HttpClient = null;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this._http = http;

    this.callVehicles();
    this.callCustomer();

   
  }
  changeCustomer(event) {
    
    this.selectedCustomer_Id = event.target.value;
    this.callVehicles();
  }
  changeStatus(event) {
    this.selectedStatus = event.target.value;
    this.callVehicles();
  }
  callVehicles() {
   
    this._http.get<VehicleDetails[]>(this.myAppUrl + 'api/VehicleData/Vehicles?Customer_Id=' + this.selectedCustomer_Id + '&Status=' + this.selectedStatus + '').subscribe(result => {
      this.vehicles = result;
    }, error => console.error(error));
  }
  callCustomer() {
    this._http.get<CustomerDetails[]>(this.myAppUrl + 'api/CustomerData/Customers').subscribe(result => {
      this.customers = result;
    }, error => console.error(error));
  }
}

interface VehicleDetails {
  name: string;
  vin: string;
  reg_No: string;
  status: string;
  last_Updated: string;
  Vehicle_Id: number;
}

interface CustomerDetails {
  customer_id: number;
  name: string;
}

