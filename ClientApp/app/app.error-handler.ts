import * as Raven from 'raven-js'
import { ToastyService } from "ng2-toasty";
import { ErrorHandler, Inject, NgZone, isDevMode} from "@angular/core";


export class AppErrorHandler implements ErrorHandler {
    constructor(
        @Inject(NgZone)private ngZone: NgZone,
        @Inject(ToastyService)private toastyService: ToastyService) {}
    
    handleError(error: any): void {
        if(!isDevMode())
            Raven.captureException(error.originalerror || error)
        else
            throw error;
            
        this.ngZone.run(() => {  //  Ng Zone will allow it to be run in the right time
            this.toastyService.error({
                title: "Error",
                msg: "The fighter was not in the right format.",
                theme: "bootstrap",
                showClose: true,
                timeout: 5000
              });  
        });
       
    }
}