import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { DataService } from '../../../shared/services/data.service';
import { MemoryStorageService } from 'src/app/shared/services/memory-storage.service';
import { IRankType, IRankSortOrder } from 'src/app/shared/interfaces';

@Component({
  selector: 'ewm-rank-type-form',
  templateUrl: './rank-type-form.component.html',
  styleUrls: ['./rank-type-form.component.scss']
})
export class RankTypeFormComponent implements OnInit {
  model: IRankType;
  originalModel: IRankType;
  sortOrders: IRankSortOrder[];

  constructor(
    private data: DataService,
    private storage: MemoryStorageService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.originalModel = <IRankType> { ...this.storage.rank.editingItem };
    this.model = this.storage.rank.editingItem;
    this.route.data
      .pipe<IRankSortOrder[]>(map(res => res['ranksortorders']))
      .subscribe(x => { this.sortOrders = x; });
  }

  ngOnInit() {
  }

  getTitle() {
    return this.originalModel.Id ? 'REDIGER' : 'OPRET';
  }

  onBackButtonClicked() {
    this.storage.rank.editingItem = null;
    this.router.navigate(['..'], { relativeTo: this.route });
  }

  getDisableSubmit(formInvalid: boolean): boolean {
    if (formInvalid) {
      return formInvalid;
    }

    return this.equals(this.model, this.originalModel);
  }

  radioButtonClicked(groupId: number) {
    this.model.SortOrderId = Number(groupId);
  }

  private equals(a: IRankType, b: IRankType): boolean {
    const equals = a.Name === b.Name && a.SortOrderId === b.SortOrderId;
    return equals;
  }

}
