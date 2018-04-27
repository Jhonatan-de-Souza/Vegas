import { fighter, SaveFighter } from './../models/fighter';
import { SaveVehicle } from "./../models/vehicle";
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/map";

@Injectable()
export class FighterService {
  constructor(private http: Http) {}
  getSkills() {
    return this.http.get("/api/fighters/skills").map(res => res.json());
  }
  create(fighter){
    return this.http.post("/api/fighter",fighter)
      .map(res => res.json(),);
  }
  
}
