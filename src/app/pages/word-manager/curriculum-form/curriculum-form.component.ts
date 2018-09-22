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

@Component({
  selector: 'ewm-curriculum-form',
  templateUrl: './curriculum-form.component.html',
  styleUrls: ['./curriculum-form.component.scss']
})
export class CurriculumFormComponent implements OnDestroy {
  model: ICurriculum;

  constructor(
    private dataService: DataService,
    private storageService: StorageService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    if (!this.model) {
      this.model = this.storageService.get(
        StorageService.Keys.EDITING_ITEM
      ) as ICurriculum;

      this.model.RankType = this.model.RankType.toUpperCase();
    }
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

  ngOnDestroy(): void {
    this.storageService.remove(StorageService.Keys.EDITING_ITEM);
  }

  private handleError(e: HttpErrorResponse) {
    console.error(e);
  }
}
