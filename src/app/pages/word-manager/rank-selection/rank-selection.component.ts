import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { IRankType } from '../../../shared/interfaces/rank-type.interface';
import { Router, ActivatedRoute } from '@angular/router';
import { StorageService } from '../../../shared/services/storage.service';
import { RankType } from '../../../shared/models/rank-type.model';

@Component({
  selector: 'ewm-rank-selection',
  templateUrl: './rank-selection.component.html',
  styleUrls: ['./rank-selection.component.scss']
})
export class RankSelectionComponent implements OnInit {
  ranks: IRankType[];
  private readonly navigateTo = 'curriculum';

  constructor(
    private dataService: DataService,
    private storageService: StorageService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    // if (this.storageService.get(StorageService.Keys.INITIAL_RANK_TYPE)) {
    //   this.router.navigate([this.navigateTo]);
    // }
  }

  async ngOnInit() {
    const result = await this.dataService.rankTypes.all();
    this.ranks = result;
  }

  onRankClicked(rankType: IRankType) {
    this.storageService.set(StorageService.Keys.RANK_TYPE, rankType);
    this.router.navigate([this.navigateTo]);
  }

  onCreateRankClicked() {
    this.storageService.set(StorageService.Keys.EDITING_ITEM, new RankType());
    this.router.navigate(['create']);
  }

  onEditRankClicked(item: IRankType) {
    this.storageService.set(StorageService.Keys.EDITING_ITEM, item);
    this.router.navigate(['edit']);
  }

  async onDeleteRankClicked(id: number) {
    await this.dataService.rankTypes.delete(id);
  }
}
