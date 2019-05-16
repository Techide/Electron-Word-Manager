import { Component, OnInit } from '@angular/core';
import { IPart } from 'src/app/shared/interfaces/part.interface';
// import { MemoryStorageService } from 'src/app/shared/services/memory-storage.service';

@Component({
  selector: 'ewm-part-form',
  templateUrl: './part-form.component.html',
  styleUrls: ['./part-form.component.scss']
})
export class PartFormComponent implements OnInit {

  model: IPart;
  originalModel: IPart;

  constructor() {
    // this.originalModel = { ...this.storage.part.editingItem };
    // this.model = this.storage.part.editingItem;
  }

  ngOnInit() { }

  getTitle(): string {
    return this.model.Id > 0 ? 'REDIGER' : 'OPRET';
  }

  onBackButtonClicked() {
    // this.storage.part.editingItem = null;
  }

  submitForm() { }
}
