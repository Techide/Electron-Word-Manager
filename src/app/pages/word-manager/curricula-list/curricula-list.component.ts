import { Component, OnInit, AfterContentInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

import { DataService } from '../../../shared/services/data.service';
import { ICurriculum } from '../../../shared/interfaces/curriculum.interface';
import { ActivatedRoute, Router, Data } from '@angular/router';
import { IPart } from 'src/app/shared/interfaces';
import { map } from 'rxjs/operators';

@Component({
  selector: 'ewm-curricula-list',
  templateUrl: './curricula-list.component.html',
  styleUrls: ['./curricula-list.component.scss']
})
export class CurriculaListComponent implements OnInit, OnChanges {
  @Input() curricula: ICurriculum[] = [];

  @Output() selectedItemChange: EventEmitter<ICurriculum> = new EventEmitter();
  private selectedCard: ICurriculum | null = null;

  constructor(
    private data: DataService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const selectedId = Number(this.route.snapshot.queryParams.selected);
    if (isNaN(selectedId)) {
      return;
    }

    const card = this.curricula.find(x => x.Id === selectedId);
    if (card) {
      this.onCardClicked(card);
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes);
  }

  anyItems(): boolean {
    return this.curricula.length > 0;
  }

  onCardClicked(card: ICurriculum): void {
    this.selectedCard = card;
    this.selectedItemChange.emit(card);
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { selected: card.Id },
      queryParamsHandling: 'merge',
      replaceUrl: true
    });
  }

  createCardClicked(): void {
    // const model = <ICurriculum> {
    //   RankType: this.storage.rank.selectedItem,
    //   RankTypeId: this.storage.rank.selectedItem.Id
    // };
    // this.storage.curriculum.editingItem = model;
    // this.navigation.navigateByUrl('/curriculum');
  }

  editItem(item: ICurriculum): void {
    // this.storage.curriculum.editingItem = item;
    // this.navigation.navigateByUrl('/curriculum');
  }

  deleteItem(item: ICurriculum): void {
    this.data.curricula.delete(item.Id)
      .subscribe(id => {
        this.curricula = this.curricula.filter(x => x.Id !== id);
      }, error => {
        const e = error as HttpErrorResponse;
        console.error(e.error);
      });
  }

  checkSelectedItem(card: ICurriculum): boolean {
    return this.selectedCard ? this.selectedCard.Id === card.Id : false;
  }
}
