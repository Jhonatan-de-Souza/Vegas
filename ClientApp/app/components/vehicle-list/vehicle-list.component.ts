import { KeyValuePair } from './../../models/vehicle';
import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../../models/vehicle';


@Component({
    templateUrl:'vehicle-list.component.html'
})
export class VehicleListComponent implements OnInit {
    vehicles: Vehicle[];
    allVehicles: Vehicle[];
    makes:KeyValuePair[];
    features:KeyValuePair;
    filter: any = {};

    constructor(private vehicleService: VehicleService){}
    
    ngOnInit(){
        this.vehicleService.getMakes()
        .subscribe(makes => this.makes = makes);
        /* Bellow we are loading the results into more than one variable */
        this.vehicleService.getVehicles()
        .subscribe(vehicles => this.vehicles = this.allVehicles = vehicles)
    }

    onFilterChange(){
         /*So basically in order to filter something you can do the following in
         * order to filter anything by either a single or multiple filters
         */
        var vehicles = this.allVehicles;

        if(this.filter.makeId)
            vehicles = vehicles.filter(v => v.make.id == this.filter.makeId); 

        this.vehicles = vehicles; 
    }
    resetFilter(){
        this.filter = {};
        this.onFilterChange(); 
    }
}