import { FetchDataComponent } from './../fetchdata/fetchdata.component';
import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { ToastyService } from 'ng2-toasty';

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
  constructor(
    private vehicleService:VehicleService,
    private toastyService: ToastyService) { }

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
      /*removing the item at the current index*/
      this.vehicle.features.splice(index,1);
    }
  }
  /* here a create an event that will handle form submission */
  submit(){
    this.vehicleService.create(this.vehicle)
    .subscribe(
      x => console.log(x),
      err => {
            this.toastyService.error({
              title: 'Error title here',
              msg: 'This is a new message',
              theme: 'bootstrap',
              showClose: true,
              timeout:5000
            });
      });
  }
}
