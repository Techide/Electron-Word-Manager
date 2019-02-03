import { DataService } from '../../../shared/services/data.service';
import { ICurriculum } from '../../../shared/interfaces/curriculum.interface';
import { HttpErrorResponse } from '@angular/common/http';
import { MemoryStorageService } from '../../../shared/services/memory-storage.service';
import { Component, OnInit } from '@angular/core';

class IErrorMessage {
  PropertyName: string;
  ErrorMessage: string;
  AttemptedValue: any;
}

@Component({
  selector: 'ewm-curriculum-form',
  templateUrl: './curriculum-form.component.html',
  styleUrls: ['./curriculum-form.component.scss']
})
export class CurriculumFormComponent implements OnInit {
  model: ICurriculum;

  originalModel: ICurriculum;

  occupiedRanks: number[];

  errors: IErrorMessage[];

  constructor(
    private dataService: DataService,
    private storageService: MemoryStorageService
  ) {
    this.model = this.storageService.curriculum.editingItem;
    this.originalModel = <ICurriculum> { ... this.storageService.curriculum.editingItem };
  }

  ngOnInit() {
    const rank = this.storageService.rank.selectedItem;
    const dataArray: number[] = [];
    this.dataService.curricula.getByRankType(rank.Id)
      .subscribe(data => {
        data.forEach(x => {
          dataArray.push(x.Rank);
        });
      });
  }

  submitForm() {
    let observable = null;
    if (this.model.Id > 0) {
      observable = this.dataService.curricula.update(this.model);
    } else {
      observable = this.dataService.curricula.create(this.model);
    }

    observable.subscribe(x => {
      this.storageService.curriculum.editingItem = x;
    }, (error: HttpErrorResponse) => this.handleError(error));

  }

  getTitle(): string {
    return this.model.Id > 0 ? 'REDIGER' : 'OPRET';
  }

  onBackButtonClicked() {
    this.storageService.curriculum.editingItem = null;
  }

  getDisableSubmit(formInvalid: boolean): boolean {
    if (formInvalid) {
      return formInvalid;
    }

    return this.equals(this.model);
  }

  sanitize(value: string) {
    return parseInt(value, 10);
  }

  private handleError(e: HttpErrorResponse) {
    this.errors = [];
    const errors = e.error.Errors as IErrorMessage[];
    errors.forEach(x => {
      this.errors.push(x);
    });
  }

  private equals(curriculum: ICurriculum): boolean {
    return curriculum.Rank === this.originalModel.Rank && curriculum.Color === this.originalModel.Color;
  }
}
