import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map } from 'rxjs/operators';

import { DataService } from '../../../shared/services/data.service';
import { MemoryStorageService } from '../../../shared/services/memory-storage.service';
import { RankType } from 'src/app/shared/models/rank-type.model';
import { IRankType, IMemproperty, ICurriculum } from 'src/app/shared/interfaces';

@Component({
  selector: 'ewm-rank-selection',
  templateUrl: './rank-selection.component.html',
  styleUrls: ['./rank-selection.component.scss']
})
export class RankSelectionComponent implements OnInit {
  ranks: IRankType[] = [];

  constructor(
    private data: DataService,
    private storage: MemoryStorageService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.route.data
      .pipe<IRankType[]>(map(data => data['ranks']))
      .subscribe(x => { this.ranks = x; });
  }

  onRankClicked(rankType: IRankType) {
    if (this.storage.rank.selectedItem && this.storage.rank.selectedItem.Id !== rankType.Id) {
      this.storage.curriculum = <IMemproperty<ICurriculum>> {};
    }

    this.storage.rank.selectedItem = rankType;
    this.router.navigate(['curricula', rankType.Id]);
  }

  onCreateRankClicked() {
    this.storage.rank.editingItem = new RankType();
    this.router.navigate(['ranktype', 'edit']);
  }

  onEditRankClicked(rankType: IRankType) {
    this.storage.rank.editingItem = rankType;
    this.router.navigate(['ranktype', 'edit']);
  }

  async onDeleteRankClicked(id: number) {
    await this.data.rankTypes.delete(id);
  }
}
