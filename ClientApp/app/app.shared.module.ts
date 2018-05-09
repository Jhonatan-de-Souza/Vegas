import { FighterService } from './services/fighter.service';
import { FighterFormComponent } from './components/fighter/fighter-form/fighter-form.component';
import { VehicleListComponent } from './components/vehicle-list/vehicle-list.component';
import * as Raven from 'raven-js';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';

import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { VehicleService } from './services/vehicle.service';
import { ErrorHandler, NgModule } from '@angular/core';
import { AppErrorHandler } from './app.error-handler';
import { FighterListComponent } from './components/fighter/fighter-list/fighter-list.component';


 Raven.config('https://0cf186e828294786899ef521603ae5b4@sentry.io/1191660')
  .install();
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    VehicleFormComponent,
    VehicleListComponent,
    FighterFormComponent,
    FighterListComponent,
  ],
  imports: [
    CommonModule,
    ToastyModule.forRoot(),
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", redirectTo: "vehicles", pathMatch: "full" },
      { path: "vehicles/new", component: VehicleFormComponent },
      { path: "vehicles/:id", component: VehicleFormComponent },
      { path: "vehicles", component: VehicleListComponent },
      { path: "fighters/new", component: FighterFormComponent },
      { path: "fighters/:id", component: FighterFormComponent },
      { path: "fighters", component: FighterListComponent },
      { path: "home", component: HomeComponent },
      { path: "**", redirectTo: "home" }
    ])
  ],
  providers: [
    {  provide: ErrorHandler,useClass:AppErrorHandler},
    VehicleService,
    FighterService
  ]
})
export class AppModuleShared {}


