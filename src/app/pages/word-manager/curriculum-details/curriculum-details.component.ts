import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { IPart } from '../../../shared/interfaces/part.interface';
import { MemoryStorageService } from 'src/app/shared/services/memory-storage.service';

export enum PartLoadStatus {
  initial,
  loading,
  ready
}

@Component({
  selector: 'ewm-curriculum-details',
  templateUrl: './curriculum-details.component.html',
  styleUrls: ['./curriculum-details.component.scss']
})
export class CurriculumDetailsComponent implements OnChanges {
  dataLoaded = false;
  PartLoadStatuses: typeof PartLoadStatus = PartLoadStatus;
  partLoadStatus: PartLoadStatus = PartLoadStatus.initial;
  @Input() parts: IPart[];

  constructor(
    private data: DataService,
    private storage: MemoryStorageService
  ) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.parts && changes.parts.currentValue) {
      this.partLoadStatus = PartLoadStatus.ready;
    }
  }

  get selected(): any {
    return this.storage.curriculum.selectedItem;
  }

  anyParts(): boolean {
    return this.parts ? this.parts.length >= 1 : false;
  }

  createPartClicked() {
    this.storage.part.editingItem = <IPart> {};
    // this.navigator.navigate(['/part']);
  }

  editPart(item: IPart): void {
    this.storage.part.editingItem = item;
    // this.navigator.navigate(['/part']);
  }

  deletePart(item: IPart): void {
    this.data.parts.delete(item.Id);
  }
}
