import { Injectable, OnDestroy } from "@angular/core";
import {
  Router,
  UrlTree,
  NavigationExtras,
  RoutesRecognized
} from "@angular/router";
import { pairwise, filter } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})
export class NavigationService implements OnDestroy {
  public previousRoute: string;

  constructor(private router: Router) {
    this.router.events
      .pipe(
        filter(x => x instanceof RoutesRecognized),
        pairwise()
      )
      .subscribe((x: any) => {
        this.previousRoute = x[0].urlAfterRedirects;
      });
  }

  navigateByUrl(
    url: string | UrlTree,
    extras?: NavigationExtras
  ): Promise<boolean> {
    return this.router.navigateByUrl(url, extras);
  }

  navigate(commands: any[], extras?: NavigationExtras): Promise<boolean> {
    return this.router.navigate(commands, extras);
  }

  navigateBack() {
    this.router.navigateByUrl(this.previousRoute).then(x => {
      if (x) {
        this.previousRoute = null;
      }
    });
  }

  ngOnDestroy(): void {
    this.router.dispose();
  }
}
