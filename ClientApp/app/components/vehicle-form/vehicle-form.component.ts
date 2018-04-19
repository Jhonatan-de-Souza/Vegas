import { isDevMode } from "@angular/core";
import { FetchDataComponent } from "./../fetchdata/fetchdata.component";
import { VehicleService } from "./../../services/vehicle.service";
import { Component, OnInit } from "@angular/core";
import { ToastyService } from "ng2-toasty";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-vehicle-form",
  templateUrl: "./vehicle-form.component.html",
  styleUrls: ["./vehicle-form.component.css"]
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  features: any[];
  vehicle: any = {
    features: [],
    contact: {}
  };
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService,
    private toastyService: ToastyService) {
      route.params.subscribe(p => {
        if(p['id']) 
         this.vehicle.id = +p['id'];
      });
  }

  ngOnInit() {
    /*Initializing the properties from the respective services*/
    // if(this.vehicle.id > 0){
    // this.vehicleService.getVehicle(this.vehicle.id)
    // .subscribe(v =>{ this.vehicle =v
    // })};
    this.vehicleService.getVehicle(this.vehicle.id)
      .subscribe(v => {
        this.vehicle = v;
    });
    this.vehicleService.getMakes().subscribe(makes => (this.makes = makes));
    this.vehicleService
      .getFeatures()
      .subscribe(features => (this.features = features));
  }
  onMakeChange() {
    /*Binding secondary actions (dropdown in this case) based on change event*/
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake.models;
    delete this.vehicle.modelId; /* removing previously selected item */
  }
  onFeatureToggle(featureId, $event) {
    /* Using javascript to obtain the selected checkbox */
    if ($event.target.checked)
      /* pushing(adding) the selected item to the angular object */
      this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      /*removing the item at the current index*/
      this.vehicle.features.splice(index, 1);
    }
  }
  /* here a create an event that will handle form submission */
  submit() {
    this.vehicleService.create(this.vehicle).subscribe(x => console.log(x));
  }
}
