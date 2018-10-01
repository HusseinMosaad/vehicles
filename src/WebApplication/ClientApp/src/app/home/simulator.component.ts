import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { fail } from 'assert';

@Component({
  selector: 'app-home',
  templateUrl: './simulator.component.html',
})
export class SimulatorComponent {
  public vehicles: VehicleDetails[];
  myAppUrl: string = "";
  _http: HttpClient = null;
  timer = [];
  public vstatus = {};
  public vint = {};

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this._http = http;
    this.callVehicles();
  }
  callVehicles() {
    this._http.get<VehicleDetails[]>(this.myAppUrl + 'api/VehicleData/Vehicles?Customer_Id=' + null + '&Status=' + null + '').subscribe(result => {
      this.vehicles = result;
    }, error => console.error(error));
  }
  buttonClick(vehicle_Id) {





    if (this.vint["v" + vehicle_Id] == undefined) {
      this.vint["v" + vehicle_Id] = null;
    }
    if (this.vint["v" + vehicle_Id] != null) {
   
      clearInterval(this.vint["v" + vehicle_Id]);
    }

    if (typeof (this.vstatus["v" + vehicle_Id]) == 'undefined') {
      this.vstatus["v" + vehicle_Id] = 0;
     
    }
   

    if (this.vstatus["v" + vehicle_Id] == 0) {
      this.vstatus["v" + vehicle_Id] = 1;
   
      var tmpvehicle_Id = vehicle_Id;
      var p_this = this;
    
      this.vint["v" + vehicle_Id] = setInterval(function () {
        var tmpvehicle_Id2 = tmpvehicle_Id;
        p_this._http.get<Boolean>(p_this.myAppUrl + "api/VehicleData/VehicleStatusUpdate?Vehicle_Id=" + tmpvehicle_Id2 + "&Status=true").subscribe(result => {

        }, error => console.error(error)); 
      }, 1000);
    
    }
    else {
      this.vstatus["v" + vehicle_Id] = 0;
     

    }


    var divele = document.getElementById("vehicle_" + vehicle_Id);
    var btnele = document.getElementById("btnvehicle_" + vehicle_Id);
        
          if (divele != null) {
            if (divele.className == "false") {
              divele.className = "true";
              btnele.className = "false";
              btnele.textContent = "Stop";
                }
            else {
              divele.className = "false";
              btnele.className = "true";
              btnele.textContent = "Start";
             
               }
           }
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

