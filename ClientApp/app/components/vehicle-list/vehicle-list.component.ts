import { KeyValuePair } from './../../models/vehicle';
import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../../models/vehicle';


@Component({
    templateUrl:'vehicle-list.component.html'
})
export class VehicleListComponent implements OnInit {
    vehicles: Vehicle[];
    makes:KeyValuePair;

    constructor(private vehicleService: VehicleService){}
    
    ngOnInit(){
        this.vehicleService.getMakes()
        .subscribe(makes => this.makes = makes);
        this.vehicleService.getVehicles()
        .subscribe(vehicles => this.vehicles = vehicles)
    }
}