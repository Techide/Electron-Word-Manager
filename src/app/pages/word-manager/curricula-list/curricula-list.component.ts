import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { ICurriculum } from '../../../shared/interfaces/curriculum.interface';
import { StorageService } from '../../../shared/services/storage.service';
import { DataService } from '../../../shared/services/data.service';
import { ModalService } from '../../../shared/services/modal.service';

import * as sorting from '../../../shared/helpers/numerical-sorting.helper';
import { IRankType } from '../../../shared/interfaces/rank-type.interface';

@Component({
  selector: 'ewm-curricula-list',
  templateUrl: './curricula-list.component.html',
  styleUrls: ['./curricula-list.component.scss']
})
export class CurriculaListComponent implements OnInit {
  curricula: ICurriculum[];

  doneLoading = false;

  constructor(
    private data: DataService,
    private storage: StorageService,
    private router: Router,
    private route: ActivatedRoute,
    private modalService: ModalService
  ) {
    if (this.storage.get(StorageService.Keys.INITIAL_RANK_TYPE)) {
      this.storage.remove(StorageService.Keys.INITIAL_RANK_TYPE);
    }
  }

  async ngOnInit() {
    const rankType = this.storage.get(StorageService.Keys.RANK_TYPE) as IRankType;
    this.curricula = await this.data.curricula
      .getByRankType(rankType.Id)
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

  createCardClicked(modalId: string) {
    this.modalService.open(modalId);
  }

}
