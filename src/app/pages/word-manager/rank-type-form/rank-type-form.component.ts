import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd, NavigationStart } from '@angular/router';
import { map } from 'rxjs/operators';
import { DataService } from '../../../shared/services/data.service';
// import { MemoryStorageService } from 'src/app/shared/services/memory-storage.service';
import { IRankType, IRankSortOrder } from 'src/app/shared/interfaces';
import { Subscription } from 'rxjs';

@Component({
  selector: 'ewm-rank-type-form',
  templateUrl: './rank-type-form.component.html',
  styleUrls: ['./rank-type-form.component.scss']
})
export class RankTypeFormComponent implements OnInit, OnDestroy {
  model: IRankType;
  originalModel: IRankType;
  sortOrders: IRankSortOrder[];

  currentSub: Subscription;

  constructor(
    private data: DataService,
    // private storage: MemoryStorageService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    // this.originalModel = <IRankType> { ...this.storage.rank.editingItem };
    // this.model = this.storage.rank.editingItem;
    this.route.data
      .pipe<IRankSortOrder[]>(map(res => res['ranksortorders']))
      .subscribe(x => { this.sortOrders = x; });

    this.currentSub = router.events.subscribe(x => {
      if (x instanceof NavigationStart) {
        // this.storage.rank.editingItem = null;
      }
    });
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.currentSub.unsubscribe();
  }

  getTitle() {
    return this.originalModel.Id ? 'REDIGER' : 'OPRET';
  }

  onBackButtonClicked() {
    this.router.navigate(['..'], { relativeTo: this.route });
  }

  getDisableSubmit(formInvalid: boolean): boolean {
    if (formInvalid) {
      return formInvalid;
    }

    return this.equals(this.model, this.originalModel);
  }

  submitForm(formData: any) {
    console.log(formData);
    // if () {
    //   this.data.rankTypes.create()
    // } else {
    //   this.data.rankTypes.create()
    // }
  }

  private equals(a: IRankType, b: IRankType): boolean {
    const equals = a.Name === b.Name && a.SortOrderId === b.SortOrderId;
    return equals;
  }

}
