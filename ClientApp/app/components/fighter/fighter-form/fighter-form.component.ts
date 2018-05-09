import { ToastyService } from "ng2-toasty";
import * as _ from "underscore";
import { FighterService } from "./../../../services/fighter.service";
import { Fighter, skills, SaveFighter } from "./../../../models/fighter";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable } from "rxjs/Observable";

@Component({
  selector: "app-fighter-form",
  templateUrl: "./fighter-form.component.html",
  styleUrls: ["./fighter-form.component.css"]
})
export class FighterFormComponent implements OnInit {
  skills: skills[];
  fighter: SaveFighter = {
    id: 0,
    name: "",
    power: 0,
    speed: 0,
     DateOfBirth: "",
    isFinalForm: false,
    skills: []
  };
  constructor(
    private route: ActivatedRoute, // this handle the currently activated route
    private router: Router, // this handles redirecting to different routes

    private fighterService: FighterService,
    private toastyService: ToastyService
  ) {
    //Below we are subscribing to the route params in order to detect an id
    route.params.subscribe(p => {
      if (p["id"]) this.fighter.id = +p["id"];
    });
  }

  ngOnInit() {
    var sources = [
      this.fighterService.getSkills()
    ]
    if (this.fighter.id)
      sources.push(this.fighterService.getFighterById(this.fighter.id))

    Observable.forkJoin(sources).subscribe(
      data => {
        this.skills = data[0];
        if (this.fighter.id) this.setFighter(data[1]);
      },    
      err => {
        //this is where you would rediret the user to a diff page
        if (err.status == 404) this.router.navigate(["/home"]);
      }
    )
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
  //Code for editing a fighter below (untestest)
  private setFighter(f: Fighter) {

    (this.fighter.id = f.id),
      (this.fighter.DateOfBirth = f.DateOfBirth),
      (this.fighter.isFinalForm = f.isFinalForm),
      (this.fighter.name = f.name),
      (this.fighter.power = f.power),
      (this.fighter.speed = f.speed),
      (this.fighter.skills = _.pluck(f.skills, "id"));
  }

  submit() 
  {
    if (this.fighter.id){
      this.fighterService.update(this.fighter)
      .subscribe(output => {
        this.toastyService.success({
          title: "Success",
          msg: "the Fighter was successfully updated!",
          theme: "bootstrap",
          showClose: true,
          timeout: 5000
        });
      });
    }
    else {
      this.fighterService.create(this.fighter)
        .subscribe(success => {// step 1 in case of successs
          this.toastyService.success({
            title: "Success",
            msg: "The fighter was sucessfully created.",
            theme: "bootstrap",
            showClose: true,
            timeout: 5000
          });
        });
    }
  }
  delete(){
    if(confirm("Are you sure?"))
      this.fighterService.delete(this.fighter.id).subscribe( x => {
        this.router.navigate(['/home']);
      });
  }
}
