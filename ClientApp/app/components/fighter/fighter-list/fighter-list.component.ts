import { platformDynamicServer } from '@angular/platform-server';
import { Component, OnInit } from "@angular/core";
import { FighterService } from "../../../services/fighter.service";
import { Fighter } from "./../../../models/fighter";

@Component({
    selector: "app-fighter-list",
    // templateUrl: "./fighter-list.component.html"
    template: `

    <h1> Fighter Listing</h1>
    <table class="table table-condensed table-hover">
    <thead>
        <tr>
            <th>Id<th>
            <th>Name<th>
            <th>Power<th>
            <th>Speed<th>
        </tr>
    </thead>
    <tbody>
        <tr *ngFor="let fighter of fighters">
            <td> {{fighter.id}}<td>
            <td> {{fighter.name}}<td>
            <td> {{fighter.power}}<td>
            <td> {{fighter.speed}}<td>
        </tr>
    </tbody>            
    </table>
    `

})
export class FighterListComponent implements OnInit {
    fighters: Fighter[];

    constructor(private fighteService: FighterService) { }

    ngOnInit() {
        this.fighteService.getFighters()
            .subscribe(fighters => this.fighters = fighters);
    }
}
