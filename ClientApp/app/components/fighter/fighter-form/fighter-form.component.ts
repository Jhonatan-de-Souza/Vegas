import { fighter, skills } from './../../../models/fighter';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: "app-fighter-form",
  templateUrl: "./fighter-form.component.html",
  styleUrls: ["./fighter-form.component.css"]
})
export class FighterFormComponent implements OnInit {
  fighter: fighter = {
    id: 0,
    name: "",
    power: 0,
    speed: 0,
    DateOfBirth:new Date(),
    isFinalForm:false,
    skills: []
  };
  constructor() {}

  ngOnInit() {}

  onSubmit() {
    console.log("Fighter Created");
  }
}
