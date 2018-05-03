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
    debugger;
    return this.http.post("/api/fighters",fighter)
      .map(res => res.json());
  }
  
}
