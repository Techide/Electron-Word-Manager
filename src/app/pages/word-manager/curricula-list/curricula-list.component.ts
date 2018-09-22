import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { map, count } from 'rxjs/operators';
import { ICurriculum } from '../../../shared/interfaces/curriculum.interface';
import { DataService } from '../../../shared/services/data.service';

import * as sorting from '../../../shared/helpers/numerical-sorting.helper';
import { IRankType } from '../../../shared/interfaces/rank-type.interface';
import { Observable } from 'rxjs';
import { EventEmitter } from '@angular/core';
import { StorageService } from '../../../shared/services/storage.service';
import { Curriculum } from '../../../shared/models/curriculum.model';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'ewm-curricula-list',
  templateUrl: './curricula-list.component.html',
  styleUrls: ['./curricula-list.component.scss']
})
export class CurriculaListComponent implements OnInit {
  curricula: ICurriculum[];

  selectedItem: number;

  rankType: IRankType;

  constructor(
    private dataService: DataService,
    private storageService: StorageService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  async ngOnInit() {
    this.rankType = this.storageService.get(
      StorageService.Keys.RANK_TYPE
    ) as IRankType;

    if (!this.rankType) {
      this.router.navigate(['..'], { relativeTo: this.route });
      return;
    }

    this.curricula = await this.dataService.curricula
      .getByRankType(this.rankType.Id)
      .then(x => {
        x.sort((a, b) => {
          if (this.rankType.Id === 1) {
            return a.Rank - b.Rank;
          }
          return b.Rank - a.Rank;
        });
        return x;
      });
  }

  anyItems(): boolean {
    return this.curricula ? this.curricula.length > 0 : false;
  }

  onCardClicked(id: number): void {
    this.selectedItem = id;
    this.router.navigate([{ outlets: { details: [id] } }], {
      relativeTo: this.route,
      skipLocationChange: true
    });
  }

  createCardClicked() {
    const model = new Curriculum();
    model.RankType = this.rankType.Name;
    this.storageService.set(StorageService.Keys.EDITING_ITEM, model);
    this.router.navigateByUrl('/curriculum/create', {
      skipLocationChange: true
    });
  }

  editItem(item: ICurriculum) {
    this.storageService.set(StorageService.Keys.EDITING_ITEM, item);
    this.router.navigateByUrl('/curriculum/edit', { skipLocationChange: true });
  }

  async deleteItem(item: ICurriculum) {
    try {
      this.dataService.curricula.delete(item.Id);
      this.curricula.forEach((x, i) => {
        if (x.Id === item.Id) {
          this.curricula.splice(i, 1);
        }
      });
    } catch (error) {
      const e = error as HttpErrorResponse;
      console.error(e.error);
    }
  }
}
