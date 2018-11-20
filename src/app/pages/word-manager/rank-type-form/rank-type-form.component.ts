import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../../../shared/services/data.service';
import { StorageService } from '../../../shared/services/storage.service';
import { IRankType } from '../../../shared/interfaces/rank-type.interface';
import { IRankSortOrder } from '../../../shared/interfaces/rank-sort-order.interface';
import { RankType } from '../../../shared/models/rank-type.model';

@Component({
  selector: 'ewm-rank-type-form',
  templateUrl: './rank-type-form.component.html',
  styleUrls: ['./rank-type-form.component.scss']
})
export class RankTypeFormComponent implements OnInit, OnDestroy {
  model: IRankType;
  originalModel: IRankType;
  sortOrders: IRankSortOrder[];

  selectedSortOrderId: number;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private dataService: DataService,
    private storageService: StorageService
  ) {}

  async ngOnInit() {
    const model = this.storageService.get(
      StorageService.Keys.EDITING_ITEM
    ) as IRankType;
    this.model = <IRankType>{ ...model };
    this.originalModel = <IRankType>{ ...model };

    const promise = this.dataService.RankSortOrdes.all();
    promise.catch(x => {
      console.error(x);
    });
    this.sortOrders = await promise;
    this.selectedSortOrderId = this.model.SortOrderId;
  }

  getTitle() {
    return this.originalModel.Id ? 'REDIGER' : 'OPRET';
  }

  onBackButtonClicked() {
    this.router.navigate(['..'], { relativeTo: this.route });
  }

  selected() {
    return this.selectedSortOrderId;
  }

  radioButtonClicked(groupId: number) {
    this.selectedSortOrderId = groupId;
  }

  ngOnDestroy(): void {
    this.storageService.remove(StorageService.Keys.EDITING_ITEM);
  }
}
