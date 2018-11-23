import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { IRankType } from '../../../shared/interfaces/rank-type.interface';
import { IRankSortOrder } from '../../../shared/interfaces/rank-sort-order.interface';
import { MemoryStorageService } from 'src/app/shared/services/memory-storage.service';
import { NavigationService } from 'src/app/shared/services/navigation.service';

@Component({
  selector: 'ewm-rank-type-form',
  templateUrl: './rank-type-form.component.html',
  styleUrls: ['./rank-type-form.component.scss']
})
export class RankTypeFormComponent implements OnInit {
  model: IRankType;
  originalModel: IRankType;
  sortOrders: IRankSortOrder[];

  selectedSortOrderId: number;

  constructor(
    private navigator: NavigationService,
    private dataService: DataService,
    private storage: MemoryStorageService
  ) {
    this.model = <IRankType> { ...this.storage.rank };
    this.originalModel = <IRankType> { ...this.storage.rank };
  }

  async ngOnInit() {

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
    this.storage.rank = null;
    this.navigator.navigateBack();
  }

  selected() {
    return this.selectedSortOrderId;
  }

  getDisableSubmit(formInvalid: boolean): boolean {
    if (formInvalid) {
      return formInvalid;
    }

    return this.equals(this.model, this.originalModel);
  }

  radioButtonClicked(groupId: number) {
    this.selectedSortOrderId = groupId;
  }

  private equals(a: IRankType, b: IRankType): boolean {
    const equals = a.Name === b.Name && a.SortOrderId === b.SortOrderId;
    return equals;
  }

}
