import { NgModule } from '@angular/core';

import { WordManagerRoutingModule } from './word-manager-routing.module';
import { CurriculumRankTypeListComponent } from './curriculum-rank-type-list/curriculum-rank-type-list.component';
import { SharedModule } from '../../shared/shared.module';
import { WordManagerComponent } from './word-manager.component';
import { RankSelectionComponent } from './rank-selection/rank-selection.component';
import { CurriculumDetailsComponent } from './curriculum-details/curriculum-details.component';
import { CurriculumPageComponent } from './curriculum-page/curriculum-page.component';
import { RankTypeFormComponent } from './rank-type-form/rank-type-form.component';

@NgModule({
  imports: [SharedModule, WordManagerRoutingModule],
  declarations: [
    CurriculumRankTypeListComponent,
    WordManagerComponent,
    RankSelectionComponent,
    CurriculumDetailsComponent,
    CurriculumPageComponent,
    RankTypeFormComponent
  ]
})
export class WordManagerModule {}
