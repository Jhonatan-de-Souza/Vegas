import { ToastyService } from "ng2-toasty";
import * as _ from "underscore";
import { FighterService } from "./../../../services/fighter.service";
import { fighter, skills } from "./../../../models/fighter";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-fighter-form",
  templateUrl: "./fighter-form.component.html",
  styleUrls: ["./fighter-form.component.css"]
})
export class FighterFormComponent implements OnInit {
  skills: skills[];
  fighter: fighter = {
    id: 0,
    name: "",
    power: 0,
    speed: 0,
    DateOfBirth: new Date(),
    isFinalForm: false,
    skills: []
  };
  constructor(
    private fighterService: FighterService,
    private toastyService: ToastyService
  ) {}

  ngOnInit() {
    /* Here i populate the models by projecting the results of the service into the local model*/
    this.fighterService
      .getSkills()
      .subscribe(data => ((this.skills = data)));
  }
  onFeatureToggle(skillId, $event) {
    /* Using javascript to obtain the selected checkbox */
    if ($event.target.checked)
      /* pushing(adding) the selected item to the angular object */
      this.fighter.skills.push(skillId);
    else {
      var index = this.fighter.skills.indexOf(skillId);
      /*removing the item at the current index*/
      this.fighter.skills.splice(index, 1);
    }
  }
  // Code for editing a fighter below (untestest)
  // private setFighter(f: fighter) {
  //   (this.fighter.id = f.id),
  //     (this.fighter.DateOfBirth = f.DateOfBirth),
  //     (this.fighter.isFinalForm = f.isFinalForm),
  //     (this.fighter.name = f.name),
  //     (this.fighter.power = f.power),
  //     (this.fighter.skills = _.pluck(f.skills, "id"));
  // }
  submit() {
    console.log("I've started the submit action")
    this.fighterService.create(this.fighter)
    .subscribe(
      //Step 1, What to do in case of success
      success =>
      this.toastyService.success({
        title: "Success",
        msg: "The fighter was sucessfully created.",
        theme: "bootstrap",
        showClose: true,
        timeout: 5000
      })
      
    );
    console.log("I've finished the submit action")
    
  }
}
