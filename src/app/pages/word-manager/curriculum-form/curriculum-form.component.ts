import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { StorageService } from '../../../shared/services/storage.service';
import { IRankType } from '../../../shared/interfaces/rank-type.interface';
import { DataService } from '../../../shared/services/data.service';
import { ICurriculum } from '../../../shared/interfaces/curriculum.interface';

class Model implements ICurriculum {
  Id: number;
  Rank: number;
  RankTypeId: number;
  RankType: string;
  Color: string;
}

@Component({
  selector: 'ewm-curriculum-form',
  templateUrl: './curriculum-form.component.html',
  styleUrls: ['./curriculum-form.component.scss']
})
export class CurriculumFormComponent implements OnInit {
  @Input()
  formClosing: EventEmitter<any>;

  model: ICurriculum;

  constructor(
    private storage: StorageService,
    private dataService: DataService
  ) {
    const rankType = this.storage.get(
      StorageService.Keys.RANK_TYPE
    ) as IRankType;
    this.model = new Model();
    this.model.RankType = rankType.Name.toUpperCase();
  }

  ngOnInit() {
    this.formClosing.subscribe(x => this.onFormClosing());
  }

  async submitForm(): Promise<void> {
    const response = await this.dataService.curricula
      .create(this.model)
      .then(x => null, e => e);
    if (response) {
      console.log(response);
      return;
    }
  }

  private onFormClosing() {
    this.model.Rank = null;
    this.model.Color = null;
  }
}
