import { Injectable, OnDestroy } from "@angular/core";
import {
  Router,
  UrlTree,
  NavigationExtras,
  NavigationEnd,
  NavigationStart
} from "@angular/router";
import { pairwise, filter, map } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})
export class NavigationService {
  public previousRoute: string;

  constructor(private router: Router) {
    this.router.events
      .pipe(
        pairwise()
      ).pipe(
        filter(x => x[0] instanceof NavigationEnd && x[1] instanceof NavigationStart),
      )
      .subscribe(x => {
        const routedEvent = <NavigationEnd> x[0];
        this.previousRoute = routedEvent.urlAfterRedirects;
      });
  }

  /**
   * Navigate based on the provided url. This navigation is always absolute.
   *
   * Returns a promise that:
   * - resolves to 'true' when navigation succeeds,
   * - resolves to 'false' when navigation fails,
   * - is rejected when an error happens.
   *
   * @param extras defaults to { skipLocationChange : true } if no extra parameters are supplied.
   */
  navigateByUrl(url: string | UrlTree, extras?: NavigationExtras): Promise<boolean> {
    const navigationExtras = extras ? extras : { skipLocationChange: true };
    return this.router.navigateByUrl(url, navigationExtras);
  }

  /**
   *  Navigate based on the provided array of commands and a starting point.
   * If no starting route is provided, the navigation is absolute.
   *
   * Returns a promise that:
   * - resolves to 'true' when navigation succeeds,
   * - resolves to 'false' when navigation fails,
   * - is rejected when an error happens.
   * 
   * @param extras defaults to { skipLocationChange : true } if no extra parameters are supplied.
   */
  navigate(commands: any[], extras?: NavigationExtras): Promise<boolean> {
    const navigationExtras = extras ? extras : { skipLocationChange: true };
    return this.router.navigate(commands, navigationExtras);
  }

  /**
   * Navigates back to the last navigated url.
   */
  navigateBack() {
    console.log(this.previousRoute);
    // if (this.previousRoute) {
    this.router
      .navigateByUrl(this.previousRoute, { skipLocationChange: true })
      .then(x => {
        if (x) {
          this.previousRoute = null;
        }
      });
    // }
  }

  // ngOnDestroy(): void {
  //   this.router.dispose();
  // }
}
