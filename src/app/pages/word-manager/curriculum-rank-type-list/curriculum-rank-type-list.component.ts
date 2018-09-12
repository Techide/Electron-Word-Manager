import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { map } from 'rxjs/operators';
import { StorageService } from '../../../shared/services/storage.service';
import { Router, ActivatedRoute } from '@angular/router';

import * as sorting from '../../../shared/helpers/numerical-sorting.helper';
import { ICurriculum } from '../../../shared/interfaces/curriculum.interface';

@Component({
  selector: 'ewm-curriculum-rank-type-list',
  templateUrl: './curriculum-rank-type-list.component.html',
  styleUrls: ['./curriculum-rank-type-list.component.scss']
})
export class CurriculumRankTypeListComponent implements OnInit {
  curricula: ICurriculum[];

  doneLoading = false;

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

  async ngOnInit() {
    this.curricula = await this.data.curricula
      .getByRankType(this.storage.get(StorageService.Keys.RANK_TYPE))
      .then(x => {
        if (x.length > 0) {
          x.sort((a, b) => sorting.descending(a.Rank, b.Rank));
        }
        return x;
      });
    this.doneLoading = true;
  }

  anyItems(): boolean {
    return !!this.curricula ? this.curricula.length > 0 : false;
  }

  onCardClicked(id: number): void {
    this.router.navigate([{ outlets: { details: [id] } }], {
      relativeTo: this.route,
      skipLocationChange: true
    });
  }
}
