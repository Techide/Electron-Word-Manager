import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { map } from 'rxjs/operators';
import { StorageService } from '../../../shared/services/storage.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'ewm-navigation-menu',
  templateUrl: './navigation-menu.component.html',
  styleUrls: ['./navigation-menu.component.scss']
})
export class NavigationMenuComponent implements OnInit {
  constructor(
    private data: DataService,
    private storage: StorageService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    if (this.storage.get(StorageService.Keys.INITIAL_RANK_TYPE)) {
      this.storage.remove(StorageService.Keys.INITIAL_RANK_TYPE);
    }
  }

  async ngOnInit(): void {
    // const curricula = await this.data.curricula.
  }

}
