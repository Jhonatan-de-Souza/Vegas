import * as Raven from 'raven-js';
import { AppErrorHandler } from './components/app/app.error-handle';
import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';

import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { VehicleService } from './services/vehicle.service';


 Raven.config('https://0cf186e828294786899ef521603ae5b4@sentry.io/1191660')
  .install();
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent,
    HomeComponent,
    VehicleFormComponent
  ],
  imports: [
    CommonModule,
    ToastyModule.forRoot(),
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", redirectTo: "home", pathMatch: "full" },
      { path: "vehicles/new", component: VehicleFormComponent },
      { path: "vehicles/:id", component: VehicleFormComponent },
      { path: "home", component: HomeComponent },
      { path: "counter", component: CounterComponent },
      { path: "fetch-data", component: FetchDataComponent },
      { path: "**", redirectTo: "home" }
    ])
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler },
    VehicleService
  ]
})
export class AppModuleShared {}
