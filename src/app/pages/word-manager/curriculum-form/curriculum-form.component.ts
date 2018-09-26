import {
  Component,
  OnInit,
  Input,
  EventEmitter,
  Output,
  OnDestroy
} from '@angular/core';
import { StorageService } from '../../../shared/services/storage.service';
import { IRankType } from '../../../shared/interfaces/rank-type.interface';
import { DataService } from '../../../shared/services/data.service';
import { ICurriculum } from '../../../shared/interfaces/curriculum.interface';
import { Router, ActivatedRoute } from '@angular/router';
import { Curriculum } from '../../../shared/models/curriculum.model';
import { HttpErrorResponse } from '@angular/common/http';
import { getViewData } from '@angular/core/src/render3/instructions';

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
export class CurriculumFormComponent implements OnDestroy, OnInit {
  model: ICurriculum;

  originalModel: ICurriculum;

  occupiedRanks: number[];

  errors: IErrorMessage[];

  constructor(
    private dataService: DataService,
    private storageService: StorageService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    if (!this.model) {
      this.model = this.getModelData();
    }
    if (!this.originalModel) {
      this.originalModel = this.getModelData();
    }
  }

  async ngOnInit(): Promise<void> {
    this.occupiedRanks = await this.getData();
  }

  async getData(): Promise<number[]> {
    const rank = this.storageService.get(
      StorageService.Keys.RANK_TYPE
    ) as IRankType;

    const dataArray: number[] = [];
    const data = await this.dataService.curricula.getByRankType(rank.Id);
    data.forEach(x => {
      dataArray.push(x.Rank);
    });
    return dataArray;
  }

  async submitForm() {
    let actionResult = null;

    try {
      if (this.model.Id > 0) {
        const originalModel = this.storageService.get(
          StorageService.Keys.EDITING_ITEM
        ) as ICurriculum;
        const model = {
          Id: originalModel.Id,
          Color: this.model.Color,
          Rank: this.model.Rank,
          OriginalRank: originalModel.Rank,
          RankType: originalModel.RankType,
          RankTypeId: originalModel.RankTypeId
        };
        actionResult = await this.dataService.curricula.update(model);
      } else {
        actionResult = await this.dataService.curricula.create(this.model);
      }

      this.router.navigate(['..'], { relativeTo: this.route });
    } catch (error) {
      this.handleError(error);
    }
  }

  getTitle(): string {
    return this.model.Id > 0 ? 'REDIGER' : 'OPRET';
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

  sanitize(value: string) {
    return parseInt(value, 10);
  }

  ngOnDestroy(): void {
    this.storageService.remove(StorageService.Keys.EDITING_ITEM);
  }

  private handleError(e: HttpErrorResponse) {
    this.errors = [];
    const errors = e.error.Errors as IErrorMessage[];
    errors.forEach(x => {
      this.errors.push(x);
    });
  }

  private getModelData(): ICurriculum {
    const data = this.storageService.get(
      StorageService.Keys.EDITING_ITEM
    ) as ICurriculum;
    data.RankType = data.RankType.toUpperCase();
    return data;
  }

  private equals(a: ICurriculum, b: ICurriculum): boolean {
    const equals = a.Rank === b.Rank && a.Color === b.Color;
    return equals;
  }
}
