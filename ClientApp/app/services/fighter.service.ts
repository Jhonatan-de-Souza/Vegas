import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/map";
import { SaveFighter } from "../models/fighter";

@Injectable()
export class FighterService {
  
  constructor(private http: Http) {}
  getSkills() {
    return this.http.get('/api/fighters/skills')
    .map(res => res.json());
  }
  getFighterById(id) {
    return this.http.get('/api/fighters/'+id)
    .map(res => res.json());
  }
  create(fighter){
    return this.http.post('/api/fighters',fighter)
      .map(res => res.json());
  }
  update(fighter:SaveFighter){
    return this.http.put('/api/fighters/'+ fighter.id,fighter)
      .map(res => res.json());
  }
  delete(id){
    return this.http.delete('/api/fighters/'+id)
      .map(res => res.json());
  }
  getFighters(){
    return this.http.get('/api/fighters')
      .map(res => res.json());
  }
}
