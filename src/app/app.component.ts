import { Component } from '@angular/core';
import { StorageService } from './shared/services/storage.service';
import { Router } from '@angular/router';


@Component({
  selector: 'ewm-root',
  template: '<router-outlet></router-outlet>'
})
export class AppComponent {
  title = 'Jiu Jutsu Gradueringer';

  constructor(private storage: StorageService, private router: Router) {
    const rankType = this.storage.get(StorageService.Keys.RANK_TYPE);
    if (rankType) {
      this.storage.set(StorageService.Keys.INITIAL_RANK_TYPE, true);
    }
  }
}
