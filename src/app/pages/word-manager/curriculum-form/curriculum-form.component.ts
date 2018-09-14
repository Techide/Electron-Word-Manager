import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { StorageService } from '../../../shared/services/storage.service';
import { IRankType } from '../../../shared/interfaces/rank-type.interface';

@Component({
  selector: 'ewm-curriculum-form',
  templateUrl: './curriculum-form.component.html',
  styleUrls: ['./curriculum-form.component.scss']
})
export class CurriculumFormComponent implements OnInit {
  @Input()
  formClosing: EventEmitter<any>;

  rankTypeName: string;

  rank: number = null;
  belt = '';

  constructor(private storage: StorageService) {
    const rankType = this.storage.get(
      StorageService.Keys.RANK_TYPE
    ) as IRankType;
    this.rankTypeName = rankType.Name.toUpperCase();
  }

  ngOnInit() {
    this.formClosing.subscribe(x => this.onFormClosing());
  }

  private onFormClosing() {
    this.rank = null;
    this.belt = null;
  }
}
