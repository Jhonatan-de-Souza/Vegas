import * as _ from "underscore";
import { isDevMode } from "@angular/core";
import { VehicleService } from "./../../services/vehicle.service";
import { Component, OnInit } from "@angular/core";
import { ToastyService } from "ng2-toasty";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable } from "rxjs/Observable";
import "rxjs/add/observable/forkJoin";

import { SaveVehicle, Vehicle } from "../../models/vehicle";

@Component({
  selector: "app-vehicle-form",
  templateUrl: "./vehicle-form.component.html",
  styleUrls: ["./vehicle-form.component.css"]
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  features: any[];
  vehicle: SaveVehicle = {
    id: 0,
    makeId: 0,
    modelId: 0,
    isRegistered: false,
    features: [],
    contact: {
      name: "",
      email: "",
      phone: ""
    }
  };
  constructor(
    private route: ActivatedRoute, // this handle the currently activated route
    private router: Router, // this handles redirecting to different routes

    private vehicleService: VehicleService,
    private toastyService: ToastyService
  ) {
    route.params.subscribe(p => {
      if (p["id"]) this.vehicle.id = +p["id"];
    });
  }

  ngOnInit() {
    /* Here we are setting up our data sources */
    var sources = [
      
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures()
    ];

    if (this.vehicle.id)
      sources.push(this.vehicleService.getVehicle(this.vehicle.id));

    Observable.forkJoin(sources).subscribe(
      data => {
        this.makes = data[0];
        this.features = data[1];
        console.log(data[1]);
        if (this.vehicle.id) this.setVehicle(data[2]);
        this.populateModels();
      },
      err => {
        if (err.status == 404) this.router.navigate(["/home"]);
      }
    );
  }
  private populateModels() {
    
    /*Binding secondary actions (dropdown in this case) based on change event*/
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake.models;
  }

  private setVehicle(v: Vehicle) {
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.isRegistered = v.isRegistered;
    this.vehicle.contact = v.contact;
    /* Using _ (underscore) is the easiest way to acess */
    this.vehicle.features = _.pluck(v.features, "id");
  }
  onMakeChange() {
  this.populateModels();
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
    if (this.vehicle.id) {
      this.vehicleService.update(this.vehicle).subscribe(x => {
        this.toastyService.success({
          title: "Success",
          msg: "The vehicle was sucessfully updated.",
          theme: "bootstrap",
          showClose: true,
          timeout: 5000
        });
      });
    } else {
      this.vehicleService.create(this.vehicle).subscribe(x => 
      this.toastyService.success({
          title: "Success",
          msg: "The vehicle was sucessfully created.",
          theme: "bootstrap",
          showClose: true,
          timeout: 5000
        })
      );
    }
  }
  delete() {
    if (confirm("Are you sure?"))
      this.vehicleService.delete(this.vehicle.id).subscribe(x => {
        this.router.navigate(['/home']);
      });
  }
}
