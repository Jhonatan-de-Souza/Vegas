import { Component, OnInit } from "@angular/core";
import { FighterService } from "../../../services/fighter.service";
import { Fighter } from "./../../../models/fighter";

@Component({
    selector: "app-fighter-list",
    // templateUrl: "./fighter-list.component.html"
    template: `<h1>This is the inline title</h1>

    <div *ngFor="let f of fighters" >
    <label for="fighters{{ f.id }}">
      {{ f.name }}
    </label>
  </div>
    `
    
})
export class FighterListComponent implements OnInit {
    fighters: Fighter[];
    constructor(private fighteService: FighterService){}

    ngOnInit(){
        
         
        this.fighteService.getFighters()
            .subscribe(fighters => this.fighters = fighters);

        this.fighteService.getFighters()
            .subscribe(fighters => console.log(fighters));

    }
}