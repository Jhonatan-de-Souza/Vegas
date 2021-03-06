import * as Raven from "raven-js";
import { ToastyService } from "ng2-toasty";
import { ErrorHandler, Inject, NgZone, isDevMode } from "@angular/core";

export class AppErrorHandler implements ErrorHandler {
  constructor(
    @Inject(NgZone) private ngZone: NgZone,
    @Inject(ToastyService) private toastyService: ToastyService
  ) {}

  handleError(error: any): void {
    if (!isDevMode()) 
     Raven.captureException(error.originalError || error);
    else
     throw error;

    this.ngZone.run(() => {
      if (typeof window !== "undefined") {
        this.toastyService.error({
          title: "Error title here",
          msg: "This is a new message",
          theme: "bootstrap",
          showClose: true,
          timeout: 5000
        });
      }
    });
  }
}
