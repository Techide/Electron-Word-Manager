import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { IRankType } from '../../../shared/interfaces/rank-type.interface';
import { Router, ActivatedRoute } from '@angular/router';
import { StorageService } from '../../../shared/services/storage.service';

@Component({
  selector: 'ewm-rank-selection',
  templateUrl: './rank-selection.component.html',
  styleUrls: ['./rank-selection.component.scss']
})
export class RankSelectionComponent implements OnInit {
  ranks: IRankType[];
  private readonly navigateTo = 'curriculum';

  constructor(
    private service: DataService,
    private storage: StorageService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    if (this.storage.get(StorageService.Keys.INITIAL_RANK_TYPE)) {
      this.router.navigate([this.navigateTo]);
    }
  }

  async ngOnInit() {
    const result = await this.service.ranks.all();
    this.ranks = result;
  }

  onRankClicked(rankType: IRankType) {
    this.storage.set(StorageService.Keys.RANK_TYPE, rankType);
    this.router.navigate([this.navigateTo]);
  }

  onCreateRankClicked() {}
}
