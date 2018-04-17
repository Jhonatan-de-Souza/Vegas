import { FetchDataComponent } from './../fetchdata/fetchdata.component';
import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  
  makes: any[];
  models: any[];
  features:any[];
  vehicle:any = {
  features:[],
  contact:{}
  };
  constructor(private vehicleService:VehicleService) { }

  ngOnInit() {
    /*Initializing the properties from the respective services*/
    this.vehicleService.getMakes().subscribe(makes => (this.makes = makes));
    this.vehicleService.getFeatures().subscribe(features => (this.features = features));
  }
  onMakeChange(){
    /*Binding secondary actions (dropdown in this case) based on change event*/
    var selectedMake = this.makes.find( m => m.id == this.vehicle.makeId)
    this.models = selectedMake.models;
    delete this.vehicle.modelId; /* removing previously selected item */
  }
  onFeatureToggle(featureId,$event){
    /* Using javascript to obtain the selected checkbox */
    if($event.target.checked)
    /* pushing(adding) the selected item to the angular object */
    this.vehicle.features.push(featureId);
    else{
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index,1);
    }
  }
}
