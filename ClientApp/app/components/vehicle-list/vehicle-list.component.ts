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
    features:KeyValuePair;

    constructor(private vehicleService: VehicleService){}
    
    ngOnInit(){
        this.vehicleService.getMakes()
        .subscribe(makes => this.makes = makes);
        this.vehicleService.getVehicles()
        .subscribe(vehicles => this.vehicles = vehicles)
        this.vehicleService.getFeatures()
        .subscribe(features => this.features = features)
        this.vehicleService.getFeatures()
        .subscribe(features => console.log(features))

    }
}