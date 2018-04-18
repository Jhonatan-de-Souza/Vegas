import { ToastyService } from 'ng2-toasty';
import { ErrorHandler,Inject } from "@angular/core";

export class AppErrorHandler implements ErrorHandler {
         constructor(
             @Inject(ToastyService) private toastyService: ToastyService) {}
         handleError(error: any): void {
             
             if (typeof(window) !== 'undefined') {
           this.toastyService.error({
             title: "Error title here",
             msg: "This is a new message",
             theme: "bootstrap",
             showClose: true,
             timeout: 5000
           });
         }
        }
       }