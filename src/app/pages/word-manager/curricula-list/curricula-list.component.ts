import { Component, OnInit, AfterContentInit, Input } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

import { DataService } from '../../../shared/services/data.service';
import { MemoryStorageService } from '../../../shared/services/memory-storage.service';
import { ICurriculum } from '../../../shared/interfaces/curriculum.interface';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'ewm-curricula-list',
  templateUrl: './curricula-list.component.html',
  styleUrls: ['./curricula-list.component.scss']
})
export class CurriculaListComponent {
  @Input() curricula: ICurriculum[];

  constructor(
    private data: DataService,
    private storage: MemoryStorageService,
    private route: ActivatedRoute
  ) { }

  anyItems(): boolean {
    return this.curricula && this.curricula.length > 0;
  }

  onCardClicked(card: ICurriculum): void {
    if (this.storage.curriculum.selectedItem && this.storage.curriculum.selectedItem.Id === card.Id) {
      return;
    }

    this.storage.curriculum.selectedItem = card;
    this.data.parts.getByCurriculumId(this.storage.curriculum.selectedItem.Id)
      .subscribe(x => {
        this.storage.part.items = x;
      });
  }

  createCardClicked(): void {
    const model = <ICurriculum> {
      RankType: this.storage.rank.selectedItem.Name,
      RankTypeId: this.storage.rank.selectedItem.Id
    };
    this.storage.curriculum.editingItem = model;
    // this.navigation.navigateByUrl('/curriculum');
  }

  editItem(item: ICurriculum): void {
    this.storage.curriculum.editingItem = item;
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

  checkSelectedItem(item: ICurriculum): boolean {
    return this.storage.curriculum.selectedItem ? this.storage.curriculum.selectedItem.Id === item.Id : false;
  }
}
